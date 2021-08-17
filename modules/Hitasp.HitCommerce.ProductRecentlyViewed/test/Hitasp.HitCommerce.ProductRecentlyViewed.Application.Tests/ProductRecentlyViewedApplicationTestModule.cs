using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(ProductRecentlyViewedApplicationModule),
        typeof(ProductRecentlyViewedDomainTestModule)
        )]
    public class ProductRecentlyViewedApplicationTestModule : AbpModule
    {

    }
}
