using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.ProductComparison.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(ProductComparisonApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ProductComparisonHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductComparisonHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ProductComparisonResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
