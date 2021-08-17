using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Contacts
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ContactsDomainSharedModule)
    )]
    public class ContactsDomainModule : AbpModule
    {

    }
}
