using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(ProductComparisonApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ProductComparisonHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ProductComparison";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProductComparisonApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
