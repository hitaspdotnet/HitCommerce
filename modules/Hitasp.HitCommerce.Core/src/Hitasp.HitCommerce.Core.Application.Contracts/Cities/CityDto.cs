using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class CityDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid StateOrProvinceId { get; set; }
    }
}