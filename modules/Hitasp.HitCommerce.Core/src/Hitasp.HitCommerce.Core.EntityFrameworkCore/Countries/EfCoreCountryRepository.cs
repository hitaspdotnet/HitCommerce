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

namespace Hitasp.HitCommerce.Core.Countries
{
    public class EfCoreCountryRepository : EfCoreRepository<CoreDbContext, Country, Guid>, ICountryRepository
    {
        public EfCoreCountryRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<Country> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText:null, name: name );
            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<Country> FindByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText:null, code3: code );
            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Country>> GetListAsync(
            string filterText = null,
            string name = null,
            string code3 = null,
            bool? isBillingEnabled = null,
            bool? isShippingEnabled = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, code3, isBillingEnabled, isShippingEnabled);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CountryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string code3 = null,
            bool? isBillingEnabled = null,
            bool? isShippingEnabled = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, code3, isBillingEnabled, isShippingEnabled);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Country> ApplyFilter(
            IQueryable<Country> query,
            string filterText,
            string name = null,
            string code3 = null,
            bool? isBillingEnabled = null,
            bool? isShippingEnabled = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Code3.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(code3), e => e.Code3.Contains(code3))
                    .WhereIf(isBillingEnabled.HasValue, e => e.IsBillingEnabled == isBillingEnabled)
                    .WhereIf(isShippingEnabled.HasValue, e => e.IsShippingEnabled == isShippingEnabled);
        }
    }
}