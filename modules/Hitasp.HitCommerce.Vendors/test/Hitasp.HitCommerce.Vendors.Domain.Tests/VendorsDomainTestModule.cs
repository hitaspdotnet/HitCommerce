using Hitasp.HitCommerce.Vendors.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Vendors
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(VendorsEntityFrameworkCoreTestModule)
        )]
    public class VendorsDomainTestModule : AbpModule
    {
        
    }
}
