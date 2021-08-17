using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.EntityFrameworkCore
{
    [ConnectionStringName(ProductRecentlyViewedDbProperties.ConnectionStringName)]
    public interface IProductRecentlyViewedDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}