using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Pricing
{
    [DependsOn(
        typeof(PricingApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class PricingHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Pricing";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(PricingApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
