using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Countries;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Countries
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CountryUpdateDto Country { get; set; }

        private readonly ICountriesAppService _countriesAppService;

        public EditModalModel(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;
        }

        public async Task OnGetAsync()
        {
            var country = await _countriesAppService.GetAsync(Id);
            Country = ObjectMapper.Map<CountryDto, CountryUpdateDto>(country);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _countriesAppService.UpdateAsync(Id, Country);
            return NoContent();
        }
    }
}