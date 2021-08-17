using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.EntityFrameworkCore
{
    [ConnectionStringName(ProductRecentlyViewedDbProperties.ConnectionStringName)]
    public class ProductRecentlyViewedDbContext : AbpDbContext<ProductRecentlyViewedDbContext>, IProductRecentlyViewedDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ProductRecentlyViewedDbContext(DbContextOptions<ProductRecentlyViewedDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProductRecentlyViewed();
        }
    }
}