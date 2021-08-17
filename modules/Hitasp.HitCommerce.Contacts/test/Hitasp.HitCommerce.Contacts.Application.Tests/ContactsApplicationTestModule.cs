using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Contacts
{
    [DependsOn(
        typeof(ContactsApplicationModule),
        typeof(ContactsDomainTestModule)
        )]
    public class ContactsApplicationTestModule : AbpModule
    {

    }
}
