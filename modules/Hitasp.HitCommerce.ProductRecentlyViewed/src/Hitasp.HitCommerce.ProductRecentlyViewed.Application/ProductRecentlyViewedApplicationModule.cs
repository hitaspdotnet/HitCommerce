using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(ProductRecentlyViewedDomainModule),
        typeof(ProductRecentlyViewedApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ProductRecentlyViewedApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ProductRecentlyViewedApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ProductRecentlyViewedApplicationModule>(validate: true);
            });
        }
    }
}
