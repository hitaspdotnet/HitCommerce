using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Payments.EntityFrameworkCore
{
    [ConnectionStringName(PaymentsDbProperties.ConnectionStringName)]
    public interface IPaymentsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}