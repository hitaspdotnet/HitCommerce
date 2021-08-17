using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Storage
{
    [DependsOn(
        typeof(StorageHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class StorageConsoleApiClientModule : AbpModule
    {
        
    }
}
