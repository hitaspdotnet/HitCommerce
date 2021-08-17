using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Contacts.EntityFrameworkCore
{
    public class ContactsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ContactsModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}