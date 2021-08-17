using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitCommerce.ProductComparison.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ProductComparisonDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProductComparisonDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProductComparisonResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ProductComparison");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ProductComparison", typeof(ProductComparisonResource));
            });
        }
    }
}
