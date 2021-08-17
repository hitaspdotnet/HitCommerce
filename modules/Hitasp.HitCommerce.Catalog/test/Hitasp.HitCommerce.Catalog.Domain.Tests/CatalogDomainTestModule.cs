using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CatalogEntityFrameworkCoreTestModule)
        )]
    public class CatalogDomainTestModule : AbpModule
    {
        
    }
}
