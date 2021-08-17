using Hitasp.HitCommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HitCommerceEntityFrameworkCoreModule),
        typeof(HitCommerceApplicationContractsModule)
    )]
    public class HitCommerceDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}