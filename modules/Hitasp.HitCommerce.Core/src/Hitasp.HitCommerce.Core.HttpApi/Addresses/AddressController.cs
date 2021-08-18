using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Addresses;

namespace Hitasp.HitCommerce.Core.Addresses
{
    [RemoteService(Name = "Core")]
    [Area("core")]
    [ControllerName("Address")]
    [Route("api/core/addresses")]
    public class AddressController : AbpController, IAddressesAppService
    {
        private readonly IAddressesAppService _addressesAppService;

        public AddressController(IAddressesAppService addressesAppService)
        {
            _addressesAppService = addressesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<AddressWithNavigationPropertiesDto>> GetListAsync(GetAddressesInput input)
        {
            return _addressesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<AddressWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _addressesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AddressDto> GetAsync(Guid id)
        {
            return _addressesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _addressesAppService.GetCountryLookupAsync(input);
        }

        [HttpGet]
        [Route("state-or-province-lookup/{countryId}")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetStateOrProvinceLookupAsync(Guid countryId, LookupRequestDto input)
        {
            return _addressesAppService.GetStateOrProvinceLookupAsync(countryId, input);
        }

        [HttpGet]
        [Route("city-lookup/{stateOrProvinceId}")]
        public Task<PagedResultDto<LookupDto<Guid?>>> GetCityLookupAsync(Guid stateOrProvinceId, LookupRequestDto input)
        {
            return _addressesAppService.GetCityLookupAsync(stateOrProvinceId, input);
        }

        [HttpGet]
        [Route("district-lookup/{cityId}")]
        public Task<PagedResultDto<LookupDto<Guid?>>> GetDistrictLookupAsync(Guid cityId, LookupRequestDto input)
        {
            return _addressesAppService.GetDistrictLookupAsync(cityId, input);
        }

        [HttpPost]
        public virtual Task<AddressDto> CreateAsync(AddressCreateDto input)
        {
            return _addressesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AddressDto> UpdateAsync(Guid id, AddressUpdateDto input)
        {
            return _addressesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _addressesAppService.DeleteAsync(id);
        }
    }
}