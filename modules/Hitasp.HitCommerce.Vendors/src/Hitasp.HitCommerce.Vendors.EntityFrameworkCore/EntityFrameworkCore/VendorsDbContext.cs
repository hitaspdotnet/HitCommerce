using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Vendors.EntityFrameworkCore
{
    [ConnectionStringName(VendorsDbProperties.ConnectionStringName)]
    public class VendorsDbContext : AbpDbContext<VendorsDbContext>, IVendorsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public VendorsDbContext(DbContextOptions<VendorsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureVendors();
        }
    }
}