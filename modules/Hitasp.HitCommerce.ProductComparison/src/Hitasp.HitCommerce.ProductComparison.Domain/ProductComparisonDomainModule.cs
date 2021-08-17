using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ProductComparisonDomainSharedModule)
    )]
    public class ProductComparisonDomainModule : AbpModule
    {

    }
}
