using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Core.Districts
{
    public interface IDistrictRepository : IRepository<District, Guid>
    {
        Task<District> FindByNameAsync(Guid cityId, [NotNull] string name, CancellationToken cancellationToken = default);
        
        Task<DistrictWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<DistrictWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            Guid? cityId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<District>> GetListAsync(
            Guid? cityId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? cityId = null,
            string filterText = null,
            string name = null,
            string type = null,
            CancellationToken cancellationToken = default);
    }
}