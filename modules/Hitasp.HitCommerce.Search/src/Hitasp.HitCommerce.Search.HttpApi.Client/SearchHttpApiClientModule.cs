using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Search
{
    [DependsOn(
        typeof(SearchApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SearchHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Search";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SearchApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
