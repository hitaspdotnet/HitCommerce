using Hitasp.HitCommerce.ProductRecentlyViewed.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ProductRecentlyViewedEntityFrameworkCoreTestModule)
        )]
    public class ProductRecentlyViewedDomainTestModule : AbpModule
    {
        
    }
}
