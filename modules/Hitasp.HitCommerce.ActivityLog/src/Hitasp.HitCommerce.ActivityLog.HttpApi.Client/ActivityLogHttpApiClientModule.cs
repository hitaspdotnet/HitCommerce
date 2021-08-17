using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ActivityLog
{
    [DependsOn(
        typeof(ActivityLogApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ActivityLogHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ActivityLog";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ActivityLogApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
