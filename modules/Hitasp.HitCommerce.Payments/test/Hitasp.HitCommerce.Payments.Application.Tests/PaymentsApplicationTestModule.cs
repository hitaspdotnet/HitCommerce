using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Payments
{
    [DependsOn(
        typeof(PaymentsApplicationModule),
        typeof(PaymentsDomainTestModule)
        )]
    public class PaymentsApplicationTestModule : AbpModule
    {

    }
}
