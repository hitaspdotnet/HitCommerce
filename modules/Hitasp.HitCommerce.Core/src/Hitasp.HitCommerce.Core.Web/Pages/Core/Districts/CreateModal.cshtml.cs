using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitasp.HitCommerce.Core.Districts;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Districts
{
    public class CreateModalModel : CorePageModel
    {
        [BindProperty]
        public DistrictCreateDto District { get; set; }

        private readonly IDistrictsAppService _districtsAppService;

        public CreateModalModel(IDistrictsAppService districtsAppService)
        {
            _districtsAppService = districtsAppService;
        }

        public async Task OnGetAsync()
        {
            District = new DistrictCreateDto();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _districtsAppService.CreateAsync(District);
            return NoContent();
        }
    }
}