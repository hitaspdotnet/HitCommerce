using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Cities;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Cities
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CityUpdateDto City { get; set; }

        public StateOrProvinceDto StateOrProvince { get; set; }

        private readonly ICitiesAppService _citiesAppService;

        public EditModalModel(ICitiesAppService citiesAppService)
        {
            _citiesAppService = citiesAppService;
        }

        public async Task OnGetAsync()
        {
            var cityWithNavigationPropertiesDto = await _citiesAppService.GetWithNavigationPropertiesAsync(Id);
            City = ObjectMapper.Map<CityDto, CityUpdateDto>(cityWithNavigationPropertiesDto.City);

            StateOrProvince = cityWithNavigationPropertiesDto.StateOrProvince;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _citiesAppService.UpdateAsync(Id, City);
            return NoContent();
        }
    }
}