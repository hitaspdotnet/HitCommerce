using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Contacts
{
    [DependsOn(
        typeof(ContactsApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ContactsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Contacts";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ContactsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
