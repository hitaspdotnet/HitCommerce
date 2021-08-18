using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class StateOrProvinceCreateDto
    {
        [Required]
        [StringLength(StateOrProvinceConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(StateOrProvinceConsts.Code3MaxLength, MinimumLength = StateOrProvinceConsts.Code3MinLength)]
        public string Code3 { get; set; }
        [StringLength(StateOrProvinceConsts.TypeMaxLength)]
        public string Type { get; set; }
        public Guid CountryId { get; set; }
    }
}