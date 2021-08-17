using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ProductRecentlyViewedDomainSharedModule)
    )]
    public class ProductRecentlyViewedDomainModule : AbpModule
    {

    }
}
