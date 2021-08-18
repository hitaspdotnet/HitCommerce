using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.Countries;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.StateOrProvinces;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.StateOrProvinces
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public StateOrProvinceUpdateDto StateOrProvince { get; set; }

        public CountryDto Country { get; set; }

        private readonly IStateOrProvincesAppService _stateOrProvincesAppService;

        public EditModalModel(IStateOrProvincesAppService stateOrProvincesAppService)
        {
            _stateOrProvincesAppService = stateOrProvincesAppService;
        }

        public async Task OnGetAsync()
        {
            var stateOrProvinceWithNavigationPropertiesDto = await _stateOrProvincesAppService.GetWithNavigationPropertiesAsync(Id);
            StateOrProvince = ObjectMapper.Map<StateOrProvinceDto, StateOrProvinceUpdateDto>(stateOrProvinceWithNavigationPropertiesDto.StateOrProvince);

            Country = stateOrProvinceWithNavigationPropertiesDto.Country;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _stateOrProvincesAppService.UpdateAsync(Id, StateOrProvince);
            return NoContent();
        }
    }
}