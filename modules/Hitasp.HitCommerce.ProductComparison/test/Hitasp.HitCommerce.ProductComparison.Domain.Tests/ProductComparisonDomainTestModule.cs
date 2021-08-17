using Hitasp.HitCommerce.ProductComparison.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductComparison
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ProductComparisonEntityFrameworkCoreTestModule)
        )]
    public class ProductComparisonDomainTestModule : AbpModule
    {
        
    }
}
