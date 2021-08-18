using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitasp.HitCommerce.Core.Addresses;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Addresses
{
    public class CreateModalModel : CorePageModel
    {
        [BindProperty]
        public AddressCreateDto Address { get; set; }

        private readonly IAddressesAppService _addressesAppService;

        public CreateModalModel(IAddressesAppService addressesAppService)
        {
            _addressesAppService = addressesAppService;
        }

        public async Task OnGetAsync()
        {
            Address = new AddressCreateDto();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _addressesAppService.CreateAsync(Address);
            return NoContent();
        }
    }
}