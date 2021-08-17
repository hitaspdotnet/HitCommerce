using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Shipments.EntityFrameworkCore
{
    [ConnectionStringName(ShipmentsDbProperties.ConnectionStringName)]
    public class ShipmentsDbContext : AbpDbContext<ShipmentsDbContext>, IShipmentsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ShipmentsDbContext(DbContextOptions<ShipmentsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureShipments();
        }
    }
}