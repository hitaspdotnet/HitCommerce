using Hitasp.HitCommerce.Tax.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Tax
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(TaxEntityFrameworkCoreTestModule)
        )]
    public class TaxDomainTestModule : AbpModule
    {
        
    }
}
