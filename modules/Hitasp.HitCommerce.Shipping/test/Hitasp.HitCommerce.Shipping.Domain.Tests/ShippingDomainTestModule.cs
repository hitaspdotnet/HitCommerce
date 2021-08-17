using Hitasp.HitCommerce.Shipping.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipping
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ShippingEntityFrameworkCoreTestModule)
        )]
    public class ShippingDomainTestModule : AbpModule
    {
        
    }
}
