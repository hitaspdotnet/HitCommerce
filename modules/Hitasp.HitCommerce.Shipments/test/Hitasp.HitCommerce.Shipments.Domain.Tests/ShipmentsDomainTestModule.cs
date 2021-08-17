using Hitasp.HitCommerce.Shipments.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipments
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ShipmentsEntityFrameworkCoreTestModule)
        )]
    public class ShipmentsDomainTestModule : AbpModule
    {
        
    }
}
