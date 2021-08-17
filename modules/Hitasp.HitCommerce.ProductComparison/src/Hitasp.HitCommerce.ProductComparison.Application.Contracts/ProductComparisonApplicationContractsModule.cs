using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(ProductComparisonDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ProductComparisonApplicationContractsModule : AbpModule
    {

    }
}
