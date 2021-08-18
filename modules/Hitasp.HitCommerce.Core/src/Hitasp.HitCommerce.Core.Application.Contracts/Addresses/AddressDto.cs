using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class AddressDto : AuditedEntityDto<Guid>
    {
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipOrPostalCode { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateOrProvinceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? DistrictId { get; set; }
    }
}