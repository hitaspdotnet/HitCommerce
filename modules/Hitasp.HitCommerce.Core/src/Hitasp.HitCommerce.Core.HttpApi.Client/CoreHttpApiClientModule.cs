using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Core
{
    [DependsOn(
        typeof(CoreApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CoreHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Core";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CoreApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
