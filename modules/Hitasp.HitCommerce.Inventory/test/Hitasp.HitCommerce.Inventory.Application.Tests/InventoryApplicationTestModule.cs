using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Inventory
{
    [DependsOn(
        typeof(InventoryApplicationModule),
        typeof(InventoryDomainTestModule)
        )]
    public class InventoryApplicationTestModule : AbpModule
    {

    }
}
