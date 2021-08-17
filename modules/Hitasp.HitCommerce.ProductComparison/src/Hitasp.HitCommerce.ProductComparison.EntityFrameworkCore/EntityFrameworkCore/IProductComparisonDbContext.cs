using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.ProductComparison.EntityFrameworkCore
{
    [ConnectionStringName(ProductComparisonDbProperties.ConnectionStringName)]
    public interface IProductComparisonDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}