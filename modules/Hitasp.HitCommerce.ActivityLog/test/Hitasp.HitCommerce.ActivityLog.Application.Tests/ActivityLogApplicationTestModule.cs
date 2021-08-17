using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ActivityLog
{
    [DependsOn(
        typeof(ActivityLogApplicationModule),
        typeof(ActivityLogDomainTestModule)
        )]
    public class ActivityLogApplicationTestModule : AbpModule
    {

    }
}
