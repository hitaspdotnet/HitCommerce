using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Orders
{
    [DependsOn(
        typeof(OrdersHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class OrdersConsoleApiClientModule : AbpModule
    {
        
    }
}
