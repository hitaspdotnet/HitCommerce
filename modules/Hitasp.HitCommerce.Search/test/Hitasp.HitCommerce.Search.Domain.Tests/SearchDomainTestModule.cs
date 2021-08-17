using Hitasp.HitCommerce.Search.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Search
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(SearchEntityFrameworkCoreTestModule)
        )]
    public class SearchDomainTestModule : AbpModule
    {
        
    }
}
