using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.Orders.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.Orders
{
    [DependsOn(
        typeof(OrdersApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class OrdersHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(OrdersHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<OrdersResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
