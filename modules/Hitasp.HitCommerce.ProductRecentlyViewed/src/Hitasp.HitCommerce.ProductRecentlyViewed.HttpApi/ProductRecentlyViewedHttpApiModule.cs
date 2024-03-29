﻿using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.ProductRecentlyViewed.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(ProductRecentlyViewedApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ProductRecentlyViewedHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductRecentlyViewedHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ProductRecentlyViewedResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
