using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitasp.HitCommerce.Core.Cities;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Cities
{
    public class CreateModalModel : CorePageModel
    {
        [BindProperty]
        public CityCreateDto City { get; set; }

        private readonly ICitiesAppService _citiesAppService;

        public CreateModalModel(ICitiesAppService citiesAppService)
        {
            _citiesAppService = citiesAppService;
        }

        public async Task OnGetAsync()
        {
            City = new CityCreateDto();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _citiesAppService.CreateAsync(City);
            return NoContent();
        }
    }
}