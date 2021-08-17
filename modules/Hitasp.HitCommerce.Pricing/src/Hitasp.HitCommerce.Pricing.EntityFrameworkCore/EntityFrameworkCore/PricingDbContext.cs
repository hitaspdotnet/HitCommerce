using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Pricing.EntityFrameworkCore
{
    [ConnectionStringName(PricingDbProperties.ConnectionStringName)]
    public class PricingDbContext : AbpDbContext<PricingDbContext>, IPricingDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public PricingDbContext(DbContextOptions<PricingDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePricing();
        }
    }
}