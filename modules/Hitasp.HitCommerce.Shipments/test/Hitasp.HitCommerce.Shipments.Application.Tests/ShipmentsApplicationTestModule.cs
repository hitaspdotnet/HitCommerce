using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipments
{
    [DependsOn(
        typeof(ShipmentsApplicationModule),
        typeof(ShipmentsDomainTestModule)
        )]
    public class ShipmentsApplicationTestModule : AbpModule
    {

    }
}
