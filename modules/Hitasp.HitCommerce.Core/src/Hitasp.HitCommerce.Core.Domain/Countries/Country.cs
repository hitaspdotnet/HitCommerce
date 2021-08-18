using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class Country : FullAuditedEntity<Guid>
    {
        [NotNull]
        public string Name { get; protected set; }

        [CanBeNull]
        public string Code3 { get; protected set; }

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        protected Country()
        {

        }

        public Country(Guid id, string name, string code3, bool isBillingEnabled, bool isShippingEnabled) : base(id)
        {
            SetName(name);
            SetCode3(code3);
            IsBillingEnabled = isBillingEnabled;
            IsShippingEnabled = isShippingEnabled;
        }

        internal virtual void SetName(string name)
        {
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CountryConsts.NameMaxLength, 0);
            Name = name;
        }

        internal virtual void SetCode3(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                Code3 = string.Empty;
                return;
            }
            
            Check.Length(code, nameof(code), CountryConsts.Code3MaxLength, 3);
            Code3 = code.ToUpper();
        }
    }
}