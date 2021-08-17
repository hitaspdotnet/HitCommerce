using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Inventory
{
    [DependsOn(
        typeof(InventoryHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class InventoryConsoleApiClientModule : AbpModule
    {
        
    }
}
