using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Storage
{
    [DependsOn(
        typeof(StorageApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class StorageHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Storage";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(StorageApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
