using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Vendors
{
    [DependsOn(
        typeof(VendorsApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class VendorsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Vendors";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(VendorsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
