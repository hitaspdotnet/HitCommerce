using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipments
{
    [DependsOn(
        typeof(ShipmentsHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ShipmentsConsoleApiClientModule : AbpModule
    {
        
    }
}
