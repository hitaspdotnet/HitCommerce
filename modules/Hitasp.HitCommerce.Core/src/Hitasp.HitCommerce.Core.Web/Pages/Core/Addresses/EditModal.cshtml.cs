using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.Districts;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Countries;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Addresses;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Addresses
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public AddressUpdateDto Address { get; set; }

        public CountryDto Country { get; set; }
        public StateOrProvinceDto StateOrProvince { get; set; }
        public CityDto City { get; set; }
        public DistrictDto District { get; set; }

        private readonly IAddressesAppService _addressesAppService;

        public EditModalModel(IAddressesAppService addressesAppService)
        {
            _addressesAppService = addressesAppService;
        }

        public async Task OnGetAsync()
        {
            var addressWithNavigationPropertiesDto = await _addressesAppService.GetWithNavigationPropertiesAsync(Id);
            Address = ObjectMapper.Map<AddressDto, AddressUpdateDto>(addressWithNavigationPropertiesDto.Address);

            Country = addressWithNavigationPropertiesDto.Country;
            StateOrProvince = addressWithNavigationPropertiesDto.StateOrProvince;
            City = addressWithNavigationPropertiesDto.City;
            District = addressWithNavigationPropertiesDto.District;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _addressesAppService.UpdateAsync(Id, Address);
            return NoContent();
        }
    }
}