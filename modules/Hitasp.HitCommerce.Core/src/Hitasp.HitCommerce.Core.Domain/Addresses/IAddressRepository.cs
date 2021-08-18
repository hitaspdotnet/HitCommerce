using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public interface IAddressRepository : IRepository<Address, Guid>
    {
        Task<AddressWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<AddressWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            Guid? countryId = null,
            Guid? stateOrProvinceId = null,
            Guid? cityId = null,
            Guid? districtId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Address>> GetListAsync(
            string filterText = null,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            Guid? countryId = null,
            Guid? stateOrProvinceId = null,
            Guid? cityId = null,
            Guid? districtId = null,
            CancellationToken cancellationToken = default);
    }
}