using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Payments
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(PaymentsDomainSharedModule)
    )]
    public class PaymentsDomainModule : AbpModule
    {

    }
}
