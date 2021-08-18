using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitasp.HitCommerce.Core.StateOrProvinces;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.StateOrProvinces
{
    public class CreateModalModel : CorePageModel
    {
        [BindProperty]
        public StateOrProvinceCreateDto StateOrProvince { get; set; }

        private readonly IStateOrProvincesAppService _stateOrProvincesAppService;

        public CreateModalModel(IStateOrProvincesAppService stateOrProvincesAppService)
        {
            _stateOrProvincesAppService = stateOrProvincesAppService;
        }

        public async Task OnGetAsync()
        {
            StateOrProvince = new StateOrProvinceCreateDto();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _stateOrProvincesAppService.CreateAsync(StateOrProvince);
            return NoContent();
        }
    }
}