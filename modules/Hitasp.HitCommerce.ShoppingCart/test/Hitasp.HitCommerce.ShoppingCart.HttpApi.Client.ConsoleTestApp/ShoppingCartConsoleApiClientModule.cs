using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ShoppingCart
{
    [DependsOn(
        typeof(ShoppingCartHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ShoppingCartConsoleApiClientModule : AbpModule
    {
        
    }
}
