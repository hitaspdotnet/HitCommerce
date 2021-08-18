using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.Shared;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Cities
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public string TypeFilter { get; set; }
        [SelectItems(nameof(StateOrProvinceLookupList))]
        public Guid StateOrProvinceIdFilter { get; set; }
        public List<SelectListItem> StateOrProvinceLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        private readonly ICitiesAppService _citiesAppService;

        public IndexModel(ICitiesAppService citiesAppService)
        {
            _citiesAppService = citiesAppService;
        }

        public async Task OnGetAsync()
        {
            StateOrProvinceLookupList.AddRange((
                    await _citiesAppService.GetStateOrProvinceLookupAsync(new LookupRequestDto
                    {
                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }
    }
}