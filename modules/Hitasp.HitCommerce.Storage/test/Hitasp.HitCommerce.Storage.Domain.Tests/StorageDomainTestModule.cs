using Hitasp.HitCommerce.Storage.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Storage
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(StorageEntityFrameworkCoreTestModule)
        )]
    public class StorageDomainTestModule : AbpModule
    {
        
    }
}
