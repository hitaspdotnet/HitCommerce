using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class CountryDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Code3 { get; set; }
        public bool IsBillingEnabled { get; set; }
        public bool IsShippingEnabled { get; set; }
    }
}