using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Hitasp.HitCommerce.Core.Countries;
using Hitasp.HitCommerce.Core.Shared;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Countries
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public string Code3Filter { get; set; }
        [SelectItems(nameof(IsBillingEnabledBoolFilterItems))]
        public string IsBillingEnabledFilter { get; set; }

        public List<SelectListItem> IsBillingEnabledBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        [SelectItems(nameof(IsShippingEnabledBoolFilterItems))]
        public string IsShippingEnabledFilter { get; set; }

        public List<SelectListItem> IsShippingEnabledBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };

        private readonly ICountriesAppService _countriesAppService;

        public IndexModel(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}