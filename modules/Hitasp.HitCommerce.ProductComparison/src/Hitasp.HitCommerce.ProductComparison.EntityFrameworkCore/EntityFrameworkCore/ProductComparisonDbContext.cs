using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ProductComparison.EntityFrameworkCore
{
    [ConnectionStringName(ProductComparisonDbProperties.ConnectionStringName)]
    public class ProductComparisonDbContext : AbpDbContext<ProductComparisonDbContext>, IProductComparisonDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ProductComparisonDbContext(DbContextOptions<ProductComparisonDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProductComparison();
        }
    }
}