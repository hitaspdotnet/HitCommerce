using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitCommerce.ShoppingCart.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ShoppingCartDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ShoppingCartDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ShoppingCartResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ShoppingCart");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ShoppingCart", typeof(ShoppingCartResource));
            });
        }
    }
}
