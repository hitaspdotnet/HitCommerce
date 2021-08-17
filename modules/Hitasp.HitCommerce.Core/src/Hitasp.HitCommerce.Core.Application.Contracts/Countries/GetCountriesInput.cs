using Volo.Abp.Application.Dtos;
using System;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class GetCountriesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Code3 { get; set; }
        public bool? IsBillingEnabled { get; set; }
        public bool? IsShippingEnabled { get; set; }

        public GetCountriesInput()
        {

        }
    }
}