using Hitasp.HitCommerce.ActivityLog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ActivityLog
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ActivityLogEntityFrameworkCoreTestModule)
        )]
    public class ActivityLogDomainTestModule : AbpModule
    {
        
    }
}
