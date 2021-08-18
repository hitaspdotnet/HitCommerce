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

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class EfCoreStateOrProvinceRepository : EfCoreRepository<CoreDbContext, StateOrProvince, Guid>,
        IStateOrProvinceRepository
    {
        public EfCoreStateOrProvinceRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<StateOrProvince> FindByNameAsync(Guid countryId, string name,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText: null, countryId: countryId, name: name);
            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<StateOrProvince> FindByCodeAsync(Guid countryId, string code,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText: null, countryId: countryId, code3: code);
            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<StateOrProvinceWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.StateOrProvince.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<StateOrProvinceWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            Guid? countryId = null,
            string filterText = null,
            string name = null,
            string code3 = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, code3, type, countryId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting)
                ? StateOrProvinceConsts.GetDefaultSorting(true)
                : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<StateOrProvinceWithNavigationProperties>>
            GetQueryForNavigationPropertiesAsync()
        {
            return from stateOrProvince in (await GetDbSetAsync())
                join country in (await GetDbContextAsync()).Countries on stateOrProvince.CountryId equals country.Id
                    into countries
                from country in countries.DefaultIfEmpty()
                select new StateOrProvinceWithNavigationProperties
                {
                    StateOrProvince = stateOrProvince,
                    Country = country
                };
        }

        protected virtual IQueryable<StateOrProvinceWithNavigationProperties> ApplyFilter(
            IQueryable<StateOrProvinceWithNavigationProperties> query,
            string filterText,
            string name = null,
            string code3 = null,
            string type = null,
            Guid? countryId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                    e => e.StateOrProvince.Name.Contains(filterText) || e.StateOrProvince.Code3.Contains(filterText) ||
                         e.StateOrProvince.Type.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.StateOrProvince.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(code3), e => e.StateOrProvince.Code3.Contains(code3))
                .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.StateOrProvince.Type.Contains(type))
                .WhereIf(countryId != null && countryId != Guid.Empty,
                    e => e.Country != null && e.Country.Id == countryId);
        }

        public async Task<List<StateOrProvince>> GetListAsync(
            Guid? countryId = null,
            string filterText = null,
            string name = null,
            string code3 = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, countryId, name, code3, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting)
                ? StateOrProvinceConsts.GetDefaultSorting(false)
                : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? countryId = null,
            string filterText = null,
            string name = null,
            string code3 = null,
            string type = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, code3, type, countryId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<StateOrProvince> ApplyFilter(
            IQueryable<StateOrProvince> query,
            string filterText,
            Guid? countryId = null,
            string name = null,
            string code3 = null,
            string type = null)
        {
            return query
                .WhereIf(countryId != null && countryId != Guid.Empty, e => e.CountryId == countryId)
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e =>
                    e.Name.Contains(filterText) ||
                    e.Code3.Contains(filterText) ||
                    e.Type.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(code3), e => e.Code3.Contains(code3))
                .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.Type.Contains(type));
        }
    }
}