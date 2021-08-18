using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Shared;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.StateOrProvinces
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public string Code3Filter { get; set; }
        public string TypeFilter { get; set; }
        [SelectItems(nameof(CountryLookupList))]
        public Guid CountryIdFilter { get; set; }
        public List<SelectListItem> CountryLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        private readonly IStateOrProvincesAppService _stateOrProvincesAppService;

        public IndexModel(IStateOrProvincesAppService stateOrProvincesAppService)
        {
            _stateOrProvincesAppService = stateOrProvincesAppService;
        }

        public async Task OnGetAsync()
        {
            CountryLookupList.AddRange((
                    await _stateOrProvincesAppService.GetCountryLookupAsync(new LookupRequestDto
                    {
                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }
    }
}