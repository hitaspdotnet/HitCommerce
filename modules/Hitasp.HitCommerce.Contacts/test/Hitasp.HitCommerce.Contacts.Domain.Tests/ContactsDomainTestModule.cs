using Hitasp.HitCommerce.Contacts.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Contacts
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ContactsEntityFrameworkCoreTestModule)
        )]
    public class ContactsDomainTestModule : AbpModule
    {
        
    }
}
