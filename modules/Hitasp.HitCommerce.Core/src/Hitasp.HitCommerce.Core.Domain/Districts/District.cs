using Hitasp.HitCommerce.Core.Cities;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class District : FullAuditedEntity<Guid>
    {
        [NotNull]
        public string Name { get; protected set; }

        [CanBeNull]
        public virtual string Type { get; set; }
        public Guid CityId { get; protected set; }

        protected District()
        {

        }

        public District(Guid id, Guid cityId, string name, string type) : base(id)
        {
            Check.Length(type, nameof(type), DistrictConsts.TypeMaxLength, 0);
            CityId = cityId;
            SetName(name);
            Type = type;
        }
        
        internal virtual void SetName(string name)
        {
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), DistrictConsts.NameMaxLength, 0);
            Name = name;
        }
    }
}