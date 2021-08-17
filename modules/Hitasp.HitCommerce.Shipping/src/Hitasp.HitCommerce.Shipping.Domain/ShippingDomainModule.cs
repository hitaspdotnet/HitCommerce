using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipping
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ShippingDomainSharedModule)
    )]
    public class ShippingDomainModule : AbpModule
    {

    }
}
