using Hitasp.HitCommerce.Payments.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Payments
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(PaymentsEntityFrameworkCoreTestModule)
        )]
    public class PaymentsDomainTestModule : AbpModule
    {
        
    }
}
