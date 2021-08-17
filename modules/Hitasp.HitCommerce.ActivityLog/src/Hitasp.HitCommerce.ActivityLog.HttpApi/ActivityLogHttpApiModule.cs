using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.ActivityLog.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.ActivityLog
{
    [DependsOn(
        typeof(ActivityLogApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ActivityLogHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ActivityLogHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ActivityLogResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
