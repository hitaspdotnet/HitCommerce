using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.Pricing.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.Pricing
{
    [DependsOn(
        typeof(PricingApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class PricingHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PricingHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<PricingResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
