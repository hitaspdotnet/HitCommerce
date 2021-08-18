using System;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class Address : AuditedEntity<Guid>
    {
        [NotNull]
        public string ContactName { get; set; }

        [NotNull]
        public string Phone { get; set; }

        [NotNull]
        public string AddressLine1 { get; set; }

        [CanBeNull]
        public virtual string AddressLine2 { get; set; }

        [CanBeNull]
        public virtual string ZipOrPostalCode { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateOrProvinceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? DistrictId { get; set; }

        protected Address()
        {

        }

        public Address(Guid id, string contactName, string phone, string addressLine1,  Guid countryId, Guid stateOrProvinceId) : base(id)
        {
            Check.NotNull(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), AddressConsts.ContactNameMaxLength, 0);
            Check.NotNull(phone, nameof(phone));
            Check.Length(phone, nameof(phone), AddressConsts.PhoneMaxLength, 0);
            Check.NotNull(addressLine1, nameof(addressLine1));
            Check.Length(addressLine1, nameof(addressLine1), AddressConsts.AddressLine1MaxLength, 0);
            CountryId = countryId;
            StateOrProvinceId = stateOrProvinceId;
            ContactName = contactName;
            Phone = phone;
            AddressLine1 = addressLine1;
        }
    }
}