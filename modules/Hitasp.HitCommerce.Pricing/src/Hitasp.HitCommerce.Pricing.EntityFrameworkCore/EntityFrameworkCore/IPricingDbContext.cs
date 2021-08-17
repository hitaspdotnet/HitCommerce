using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Pricing.EntityFrameworkCore
{
    [ConnectionStringName(PricingDbProperties.ConnectionStringName)]
    public interface IPricingDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}