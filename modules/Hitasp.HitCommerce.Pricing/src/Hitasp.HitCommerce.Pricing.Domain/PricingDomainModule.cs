using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Pricing
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(PricingDomainSharedModule)
    )]
    public class PricingDomainModule : AbpModule
    {

    }
}
