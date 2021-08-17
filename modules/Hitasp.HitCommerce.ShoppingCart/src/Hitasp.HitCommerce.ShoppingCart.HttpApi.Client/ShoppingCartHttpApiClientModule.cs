using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(ShoppingCartApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ShoppingCartHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ShoppingCart";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ShoppingCartApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
