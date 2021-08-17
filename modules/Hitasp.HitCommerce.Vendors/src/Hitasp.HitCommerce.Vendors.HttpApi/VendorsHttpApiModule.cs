using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.Vendors.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.Vendors
{
    [DependsOn(
        typeof(VendorsApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class VendorsHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(VendorsHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<VendorsResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
