using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Tax.EntityFrameworkCore
{
    [ConnectionStringName(TaxDbProperties.ConnectionStringName)]
    public class TaxDbContext : AbpDbContext<TaxDbContext>, ITaxDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public TaxDbContext(DbContextOptions<TaxDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureTax();
        }
    }
}