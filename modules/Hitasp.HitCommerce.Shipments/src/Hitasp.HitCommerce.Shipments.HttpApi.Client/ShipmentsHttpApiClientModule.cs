using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipments
{
    [DependsOn(
        typeof(ShipmentsApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ShipmentsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Shipments";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ShipmentsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
