using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ActivityLog
{
    [DependsOn(
        typeof(ActivityLogHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ActivityLogConsoleApiClientModule : AbpModule
    {
        
    }
}
