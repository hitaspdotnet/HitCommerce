using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Orders.EntityFrameworkCore
{
    [ConnectionStringName(OrdersDbProperties.ConnectionStringName)]
    public interface IOrdersDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}