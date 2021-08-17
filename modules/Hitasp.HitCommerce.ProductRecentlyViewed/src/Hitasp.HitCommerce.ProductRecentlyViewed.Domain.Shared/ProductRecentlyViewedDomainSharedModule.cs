using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitCommerce.ProductRecentlyViewed.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ProductRecentlyViewedDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProductRecentlyViewedDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProductRecentlyViewedResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ProductRecentlyViewed");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ProductRecentlyViewed", typeof(ProductRecentlyViewedResource));
            });
        }
    }
}
