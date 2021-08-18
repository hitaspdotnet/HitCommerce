using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public interface IAddressesAppService : IApplicationService
    {
        Task<PagedResultDto<AddressWithNavigationPropertiesDto>> GetListAsync(GetAddressesInput input);

        Task<AddressWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<AddressDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetStateOrProvinceLookupAsync(Guid? countryId, LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid?>>> GetCityLookupAsync(Guid? stateOrProvinceId, LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid?>>> GetDistrictLookupAsync(Guid? cityId, LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<AddressDto> CreateAsync(AddressCreateDto input);

        Task<AddressDto> UpdateAsync(Guid id, AddressUpdateDto input);
    }
}