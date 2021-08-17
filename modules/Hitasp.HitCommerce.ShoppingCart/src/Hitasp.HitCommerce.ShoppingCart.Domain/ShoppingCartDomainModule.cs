using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ShoppingCartDomainSharedModule)
    )]
    public class ShoppingCartDomainModule : AbpModule
    {

    }
}
