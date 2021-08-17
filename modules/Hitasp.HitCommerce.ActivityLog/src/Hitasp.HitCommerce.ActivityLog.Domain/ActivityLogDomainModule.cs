using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ActivityLog
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ActivityLogDomainSharedModule)
    )]
    public class ActivityLogDomainModule : AbpModule
    {

    }
}
