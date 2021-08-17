using Hitasp.HitCommerce.Pricing.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Pricing
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(PricingEntityFrameworkCoreTestModule)
        )]
    public class PricingDomainTestModule : AbpModule
    {
        
    }
}
