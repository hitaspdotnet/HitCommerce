using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.ShoppingCart.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(ShoppingCartApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ShoppingCartHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ShoppingCartHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ShoppingCartResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
