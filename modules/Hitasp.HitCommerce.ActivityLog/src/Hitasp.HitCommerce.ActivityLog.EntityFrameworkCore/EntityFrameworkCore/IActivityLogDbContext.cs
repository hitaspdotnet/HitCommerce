using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ActivityLog.EntityFrameworkCore
{
    [ConnectionStringName(ActivityLogDbProperties.ConnectionStringName)]
    public interface IActivityLogDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}