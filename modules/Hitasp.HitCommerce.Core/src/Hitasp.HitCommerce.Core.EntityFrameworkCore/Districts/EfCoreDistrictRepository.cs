using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.Core.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class EfCoreDistrictRepository : EfCoreRepository<CoreDbContext, District, Guid>, IDistrictRepository
    {
        public EfCoreDistrictRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<District> FindByNameAsync(Guid cityId, string name, CancellationToken cancellationToken = default)
        {
            return await base.FindAsync(x => x.CityId == cityId && x.Name == name, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task<DistrictWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.District.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<DistrictWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            Guid? cityId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, cityId, name, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting)
                ? DistrictConsts.GetDefaultSorting(true)
                : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<DistrictWithNavigationProperties>>
            GetQueryForNavigationPropertiesAsync()
        {
            return from district in (await GetDbSetAsync())
                join city in (await GetDbContextAsync()).Cities on district.CityId equals city.Id into cities
                from city in cities.DefaultIfEmpty()
                select new DistrictWithNavigationProperties
                {
                    District = district,
                    City = city
                };
        }

        protected virtual IQueryable<DistrictWithNavigationProperties> ApplyFilter(
            IQueryable<DistrictWithNavigationProperties> query,
            string filterText,
            Guid? cityId = null,
            string name = null,
            string type = null)
        {
            return query
                .WhereIf(cityId != null && cityId != Guid.Empty, e => e.City != null && e.City.Id == cityId)
                .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                    e => e.District.Name.Contains(filterText) || e.District.Type.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.District.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.District.Type.Contains(type));
        }

        public async Task<List<District>> GetListAsync(
            Guid? cityId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, cityId, name, type);
            query = query.OrderBy(
                string.IsNullOrWhiteSpace(sorting) ? DistrictConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? cityId = null,
            string filterText = null,
            string name = null,
            string type = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, cityId, name, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<District> ApplyFilter(
            IQueryable<District> query,
            string filterText,
            Guid? cityId = null,
            string name = null,
            string type = null)
        {
            return query
                .WhereIf(cityId != null && cityId != Guid.Empty, e => e.CityId == cityId)
                .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                    e => e.Name.Contains(filterText) || e.Type.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.Type.Contains(type));
        }
    }
}