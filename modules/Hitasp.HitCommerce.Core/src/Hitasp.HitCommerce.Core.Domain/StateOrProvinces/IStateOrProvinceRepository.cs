using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public interface IStateOrProvinceRepository : IRepository<StateOrProvince, Guid>
    {
        Task<StateOrProvince> FindByNameAsync(Guid countryId, [NotNull] string name, CancellationToken cancellationToken = default);
        
        Task<StateOrProvince> FindByCodeAsync(Guid countryId, [NotNull] string code, CancellationToken cancellationToken = default);
        
        Task<StateOrProvinceWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<StateOrProvinceWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            Guid? countryId = null,
            string filterText = null,
            string name = null,
            string code3 = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<StateOrProvince>> GetListAsync(
            Guid? countryId = null,
            string filterText = null,
            string name = null,
            string code3 = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? countryId = null,
            string filterText = null,
            string name = null,
            string code3 = null,
            string type = null,
            CancellationToken cancellationToken = default);
    }
}