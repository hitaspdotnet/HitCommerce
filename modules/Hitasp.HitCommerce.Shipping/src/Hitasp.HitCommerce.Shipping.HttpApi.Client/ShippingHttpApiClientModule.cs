using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipping
{
    [DependsOn(
        typeof(ShippingApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ShippingHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Shipping";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ShippingApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
