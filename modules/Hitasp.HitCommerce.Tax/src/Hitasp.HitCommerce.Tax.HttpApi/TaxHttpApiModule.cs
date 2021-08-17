using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.Tax.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.Tax
{
    [DependsOn(
        typeof(TaxApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class TaxHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(TaxHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<TaxResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
