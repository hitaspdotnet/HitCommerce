using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Tax.EntityFrameworkCore
{
    [ConnectionStringName(TaxDbProperties.ConnectionStringName)]
    public interface ITaxDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}