using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitasp.HitCommerce.Core.Countries;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Countries
{
    public class CreateModalModel : CorePageModel
    {
        [BindProperty]
        public CountryCreateDto Country { get; set; }

        private readonly ICountriesAppService _countriesAppService;

        public CreateModalModel(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;
        }

        public async Task OnGetAsync()
        {
            Country = new CountryCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _countriesAppService.CreateAsync(Country);
            return NoContent();
        }
    }
}