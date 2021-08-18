using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class DistrictCreateDto
    {
        [Required]
        [StringLength(DistrictConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(DistrictConsts.TypeMaxLength)]
        public string Type { get; set; }
        public Guid CityId { get; set; }
    }
}