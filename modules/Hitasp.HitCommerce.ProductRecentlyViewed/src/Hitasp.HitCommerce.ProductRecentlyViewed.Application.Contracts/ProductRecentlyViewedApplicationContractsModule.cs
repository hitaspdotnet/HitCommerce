using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(ProductRecentlyViewedDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ProductRecentlyViewedApplicationContractsModule : AbpModule
    {

    }
}
