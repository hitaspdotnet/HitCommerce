using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Vendors
{
    [DependsOn(
        typeof(VendorsHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class VendorsConsoleApiClientModule : AbpModule
    {
        
    }
}
