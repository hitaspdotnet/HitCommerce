using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipping
{
    [DependsOn(
        typeof(ShippingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ShippingConsoleApiClientModule : AbpModule
    {
        
    }
}
