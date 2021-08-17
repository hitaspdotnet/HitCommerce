using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(ShoppingCartDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ShoppingCartApplicationContractsModule : AbpModule
    {

    }
}
