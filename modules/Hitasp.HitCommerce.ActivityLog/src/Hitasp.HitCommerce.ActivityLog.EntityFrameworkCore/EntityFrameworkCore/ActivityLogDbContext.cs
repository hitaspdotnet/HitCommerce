using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ActivityLog.EntityFrameworkCore
{
    [ConnectionStringName(ActivityLogDbProperties.ConnectionStringName)]
    public class ActivityLogDbContext : AbpDbContext<ActivityLogDbContext>, IActivityLogDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ActivityLogDbContext(DbContextOptions<ActivityLogDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureActivityLog();
        }
    }
}