using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Search
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(SearchDomainSharedModule)
    )]
    public class SearchDomainModule : AbpModule
    {

    }
}
