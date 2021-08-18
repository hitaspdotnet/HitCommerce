using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Core.Cities
{
    public interface ICityRepository : IRepository<City, Guid>
    {
        Task<City> FindByNameAsync(Guid stateOrProvinceId, [NotNull] string name, CancellationToken cancellationToken = default);
        
        Task<CityWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<CityWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            Guid? stateOrProvinceId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<City>> GetListAsync(
            Guid? stateOrProvinceId = null,
            string filterText = null,
            string name = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? stateOrProvinceId = null,
            string filterText = null,
            string name = null,
            string type = null,
            CancellationToken cancellationToken = default);
    }
}