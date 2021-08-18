using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class DistrictDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid CityId { get; set; }
    }
}