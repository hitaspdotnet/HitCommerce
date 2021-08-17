using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Core
{
    [DependsOn(
        typeof(CoreHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CoreConsoleApiClientModule : AbpModule
    {
        
    }
}
