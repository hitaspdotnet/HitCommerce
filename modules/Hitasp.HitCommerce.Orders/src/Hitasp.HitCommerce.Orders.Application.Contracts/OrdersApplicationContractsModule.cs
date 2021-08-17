using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Hitasp.HitCommerce.Orders
{
    [DependsOn(
        typeof(OrdersDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class OrdersApplicationContractsModule : AbpModule
    {

    }
}
