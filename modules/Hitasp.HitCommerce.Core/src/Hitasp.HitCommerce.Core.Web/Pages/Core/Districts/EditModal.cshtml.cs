using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.Cities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Districts;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Districts
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public DistrictUpdateDto District { get; set; }

        public CityDto City { get; set; }

        private readonly IDistrictsAppService _districtsAppService;

        public EditModalModel(IDistrictsAppService districtsAppService)
        {
            _districtsAppService = districtsAppService;
        }

        public async Task OnGetAsync()
        {
            var districtWithNavigationPropertiesDto = await _districtsAppService.GetWithNavigationPropertiesAsync(Id);
            District = ObjectMapper.Map<DistrictDto, DistrictUpdateDto>(districtWithNavigationPropertiesDto.District);

            City = districtWithNavigationPropertiesDto.City;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _districtsAppService.UpdateAsync(Id, District);
            return NoContent();
        }
    }
}