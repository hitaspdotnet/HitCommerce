using Hitasp.HitCommerce.Core.Countries;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class StateOrProvince : FullAuditedEntity<Guid>
    {
        [NotNull]
        public string Name { get; protected set; }

        [CanBeNull]
        public string Code3 { get; protected set; }

        [CanBeNull]
        public virtual string Type { get; set; }
        public Guid CountryId { get; protected set; }

        protected StateOrProvince()
        {

        }

        public StateOrProvince(Guid id, Guid countryId, string name, string code3, string type) : base(id)
        {
            CountryId = countryId;
            SetName(name);
            SetCode3(code3);
            Type = type;
        }
        
        internal virtual void SetName(string name)
        {
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), StateOrProvinceConsts.NameMaxLength, 0);
            Name = name;
        }

        internal virtual void SetCode3(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                Code3 = string.Empty;
                return;
            }
            
            Check.Length(code, nameof(code), StateOrProvinceConsts.Code3MaxLength, StateOrProvinceConsts.Code3MinLength);
            Code3 = code.ToUpper();
        }
    }
}