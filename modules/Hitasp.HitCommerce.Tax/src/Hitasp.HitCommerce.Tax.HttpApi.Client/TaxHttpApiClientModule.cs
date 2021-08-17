using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Tax
{
    [DependsOn(
        typeof(TaxApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class TaxHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Tax";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(TaxApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
