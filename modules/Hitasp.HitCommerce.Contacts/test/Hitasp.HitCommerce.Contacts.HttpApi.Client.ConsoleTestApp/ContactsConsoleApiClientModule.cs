using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Contacts
{
    [DependsOn(
        typeof(ContactsHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ContactsConsoleApiClientModule : AbpModule
    {
        
    }
}
