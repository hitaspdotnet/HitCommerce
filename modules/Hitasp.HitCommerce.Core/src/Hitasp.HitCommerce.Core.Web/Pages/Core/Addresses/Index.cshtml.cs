using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Hitasp.HitCommerce.Core.Addresses;
using Hitasp.HitCommerce.Core.Shared;

namespace Hitasp.HitCommerce.Core.Web.Pages.Core.Addresses
{
    public class IndexModel : AbpPageModel
    {
        public string ContactNameFilter { get; set; }
        public string PhoneFilter { get; set; }
        public string AddressLine1Filter { get; set; }
        public string AddressLine2Filter { get; set; }
        public string ZipOrPostalCodeFilter { get; set; }
        [SelectItems(nameof(CountryLookupList))]
        public Guid CountryIdFilter { get; set; }
        public List<SelectListItem> CountryLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        [SelectItems(nameof(StateOrProvinceLookupList))]
        public Guid StateOrProvinceIdFilter { get; set; }
        public List<SelectListItem> StateOrProvinceLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        [SelectItems(nameof(CityLookupList))]
        public Guid? CityIdFilter { get; set; }
        public List<SelectListItem> CityLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        [SelectItems(nameof(DistrictLookupList))]
        public Guid? DistrictIdFilter { get; set; }
        public List<SelectListItem> DistrictLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        private readonly IAddressesAppService _addressesAppService;

        public IndexModel(IAddressesAppService addressesAppService)
        {
            _addressesAppService = addressesAppService;
        }

        public async Task OnGetAsync()
        {
            var countries = await _addressesAppService.GetCountryLookupAsync(new LookupRequestDto
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
            });
            
            CountryLookupList.AddRange(countries.Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            if (countries.Items.Any())
            {
                var stateOrProvince = await _addressesAppService.GetStateOrProvinceLookupAsync(countries.Items[0].Id, new LookupRequestDto
                {
                    MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                });
                StateOrProvinceLookupList.AddRange(
                    stateOrProvince.Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
                );

                if (stateOrProvince.Items.Any())
                {
                    var cities = 
                        await _addressesAppService.GetCityLookupAsync(stateOrProvince.Items[0].Id,new LookupRequestDto
                        {
                            MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                        });
                    CityLookupList.AddRange(cities.Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
                    );

                    if (cities.Items.Any() && cities.Items[0].Id.HasValue)
                    {
                        var districts =
                            await _addressesAppService.GetDistrictLookupAsync(cities.Items[0].Id.Value, new LookupRequestDto
                            {
                                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                            });
                        DistrictLookupList.AddRange(districts.Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
                        );
                    }
                }
            }

            await Task.CompletedTask;
        }
    }
}