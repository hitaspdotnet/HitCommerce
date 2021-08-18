using Hitasp.HitCommerce.Core.StateOrProvinces;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class City : FullAuditedEntity<Guid>
    {
        [NotNull]
        public string Name { get; protected set; }

        [CanBeNull]
        public virtual string Type { get; set; }
        public Guid StateOrProvinceId { get; protected set; }

        protected City()
        {

        }

        public City(Guid id, Guid stateOrProvinceId, string name, string type) : base(id)
        {
            Check.Length(type, nameof(type), CityConsts.TypeMaxLength, 0);
            StateOrProvinceId = stateOrProvinceId;
            SetName(name);
            Type = type;
        }
        
        internal virtual void SetName(string name)
        {
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CityConsts.NameMaxLength, 0);
            Name = name;
        }

    }
}