using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Payments
{
    [DependsOn(
        typeof(PaymentsApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class PaymentsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Payments";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(PaymentsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
