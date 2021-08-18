using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class CityUpdateDto
    {
        [Required]
        [StringLength(CityConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(CityConsts.TypeMaxLength)]
        public string Type { get; set; }
        public Guid StateOrProvinceId { get; set; }
    }
}