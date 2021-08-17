using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Orders
{
    [DependsOn(
        typeof(OrdersApplicationModule),
        typeof(OrdersDomainTestModule)
        )]
    public class OrdersApplicationTestModule : AbpModule
    {

    }
}
