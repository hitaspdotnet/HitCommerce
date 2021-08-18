using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class AddressUpdateDto
    {
        [Required]
        [StringLength(AddressConsts.ContactNameMaxLength)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(AddressConsts.PhoneMaxLength)]
        public string Phone { get; set; }
        [Required]
        [StringLength(AddressConsts.AddressLine1MaxLength)]
        public string AddressLine1 { get; set; }
        [StringLength(AddressConsts.AddressLine2MaxLength)]
        public string AddressLine2 { get; set; }
        [RegularExpression(@"(?i)^[a-z0-9][a-z0-9\- ]{0,10}[a-z0-9]$")]
        [StringLength(AddressConsts.ZipOrPostalCodeMaxLength)]
        public string ZipOrPostalCode { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateOrProvinceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? DistrictId { get; set; }
    }
}