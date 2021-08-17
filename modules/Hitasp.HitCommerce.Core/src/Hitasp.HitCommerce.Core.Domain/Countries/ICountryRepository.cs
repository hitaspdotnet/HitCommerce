using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Core.Countries
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {
        Task<Country> FindByNameAsync([NotNull] string name, CancellationToken cancellationToken = default);
        
        Task<Country> FindByCodeAsync([NotNull] string code, CancellationToken cancellationToken = default);
        
        Task<List<Country>> GetListAsync(
            string filterText = null,
            string name = null,
            string code3 = null,
            bool? isBillingEnabled = null,
            bool? isShippingEnabled = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string code3 = null,
            bool? isBillingEnabled = null,
            bool? isShippingEnabled = null,
            CancellationToken cancellationToken = default);
    }
}