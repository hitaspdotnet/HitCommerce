using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Hitasp.HitCommerce.Core.Districts;
using Hitasp.HitCommerce.Core.Shared;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Districts
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public string TypeFilter { get; set; }
        [SelectItems(nameof(CityLookupList))]
        public Guid CityIdFilter { get; set; }
        public List<SelectListItem> CityLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        private readonly IDistrictsAppService _districtsAppService;

        public IndexModel(IDistrictsAppService districtsAppService)
        {
            _districtsAppService = districtsAppService;
        }

        public async Task OnGetAsync()
        {
            CityLookupList.AddRange((
                    await _districtsAppService.GetCityLookupAsync(new LookupRequestDto
                    {
                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }
    }
}