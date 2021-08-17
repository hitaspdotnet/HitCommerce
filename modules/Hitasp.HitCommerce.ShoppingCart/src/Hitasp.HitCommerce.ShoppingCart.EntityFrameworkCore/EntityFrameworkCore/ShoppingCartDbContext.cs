using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ShoppingCart.EntityFrameworkCore
{
    [ConnectionStringName(ShoppingCartDbProperties.ConnectionStringName)]
    public class ShoppingCartDbContext : AbpDbContext<ShoppingCartDbContext>, IShoppingCartDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureShoppingCart();
        }
    }
}