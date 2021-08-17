using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class CountryUpdateDto
    {
        [Required]
        [StringLength(CountryConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(CountryConsts.Code3MaxLength)]
        public string Code3 { get; set; }
        public bool IsBillingEnabled { get; set; }
        public bool IsShippingEnabled { get; set; }
    }
}