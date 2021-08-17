using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Shipping
{
    [DependsOn(
        typeof(ShippingApplicationModule),
        typeof(ShippingDomainTestModule)
        )]
    public class ShippingApplicationTestModule : AbpModule
    {

    }
}
