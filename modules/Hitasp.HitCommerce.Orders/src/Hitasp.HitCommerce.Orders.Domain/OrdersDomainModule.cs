using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Orders
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(OrdersDomainSharedModule)
    )]
    public class OrdersDomainModule : AbpModule
    {

    }
}
