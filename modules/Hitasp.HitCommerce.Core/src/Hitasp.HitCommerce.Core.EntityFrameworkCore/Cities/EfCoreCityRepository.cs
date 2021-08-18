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

namespace Hitasp.HitCommerce.Core.Cities
{
    public class EfCoreCityRepository : EfCoreRepository<CoreDbContext, City, Guid>, ICityRepository
    {
        public EfCoreCityRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<City> FindByNameAsync(Guid stateOrProvinceId, string name, CancellationToken cancellationToken = default)
        {
            return await base.FindAsync(x => x.StateOrProvinceId == stateOrProvinceId && x.Name == name, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task<CityWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.City.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CityWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            Guid? stateOrProvinceId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, stateOrProvinceId, name, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CityConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<CityWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from city in (await GetDbSetAsync())
                join stateOrProvince in (await GetDbContextAsync()).StateOrProvinces on city.StateOrProvinceId equals
                    stateOrProvince.Id into stateOrProvinces
                from stateOrProvince in stateOrProvinces.DefaultIfEmpty()
                select new CityWithNavigationProperties
                {
                    City = city,
                    StateOrProvince = stateOrProvince
                };
        }

        protected virtual IQueryable<CityWithNavigationProperties> ApplyFilter(
            IQueryable<CityWithNavigationProperties> query,
            string filterText,
            Guid? stateOrProvinceId = null,
            string name = null,
            string type = null)
        {
            return query
                .WhereIf(stateOrProvinceId != null && stateOrProvinceId != Guid.Empty,
                    e => e.StateOrProvince != null && e.StateOrProvince.Id == stateOrProvinceId)
                .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                    e => e.City.Name.Contains(filterText) || e.City.Type.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.City.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.City.Type.Contains(type));
        }

        public async Task<List<City>> GetListAsync(
            Guid? stateOrProvinceId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, stateOrProvinceId, name, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CityConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? stateOrProvinceId = null,
            string filterText = null,
            string name = null,
            string type = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, stateOrProvinceId, name, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<City> ApplyFilter(
            IQueryable<City> query,
            string filterText,
            Guid? stateOrProvinceId = null,
            string name = null,
            string type = null)
        {
            return query
                .WhereIf(stateOrProvinceId != null && stateOrProvinceId != Guid.Empty,
                    e => e.StateOrProvinceId == stateOrProvinceId)
                .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                    e => e.Name.Contains(filterText) || e.Type.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.Type.Contains(type));
        }
    }
}