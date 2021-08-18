using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class StateOrProvinceDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Code3 { get; set; }
        public string Type { get; set; }
        public Guid CountryId { get; set; }
    }
}