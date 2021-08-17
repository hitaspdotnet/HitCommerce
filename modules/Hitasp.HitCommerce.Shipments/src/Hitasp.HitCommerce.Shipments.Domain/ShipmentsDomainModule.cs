using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipments
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ShipmentsDomainSharedModule)
    )]
    public class ShipmentsDomainModule : AbpModule
    {

    }
}
