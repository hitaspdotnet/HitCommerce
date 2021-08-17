using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Inventory
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(InventoryDomainSharedModule)
    )]
    public class InventoryDomainModule : AbpModule
    {

    }
}
