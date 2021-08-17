using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Pricing
{
    [DependsOn(
        typeof(PricingApplicationModule),
        typeof(PricingDomainTestModule)
        )]
    public class PricingApplicationTestModule : AbpModule
    {

    }
}
