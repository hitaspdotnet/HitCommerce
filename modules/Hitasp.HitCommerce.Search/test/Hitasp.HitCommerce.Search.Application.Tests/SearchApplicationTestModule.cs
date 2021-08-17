using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Search
{
    [DependsOn(
        typeof(SearchApplicationModule),
        typeof(SearchDomainTestModule)
        )]
    public class SearchApplicationTestModule : AbpModule
    {

    }
}
