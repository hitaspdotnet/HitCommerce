using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(ProductRecentlyViewedApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ProductRecentlyViewedHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ProductRecentlyViewed";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProductRecentlyViewedApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
