using Volo.Abp.Application.Dtos;
using System;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class GetAddressesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipOrPostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? StateOrProvinceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? DistrictId { get; set; }

        public GetAddressesInput()
        {

        }
    }
}