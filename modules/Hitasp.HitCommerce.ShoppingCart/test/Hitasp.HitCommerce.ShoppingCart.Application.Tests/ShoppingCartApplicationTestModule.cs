using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(ShoppingCartApplicationModule),
        typeof(ShoppingCartDomainTestModule)
        )]
    public class ShoppingCartApplicationTestModule : AbpModule
    {

    }
}
