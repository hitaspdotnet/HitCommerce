using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(ProductComparisonApplicationModule),
        typeof(ProductComparisonDomainTestModule)
        )]
    public class ProductComparisonApplicationTestModule : AbpModule
    {

    }
}
