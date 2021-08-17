using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Shipping.EntityFrameworkCore
{
    [ConnectionStringName(ShippingDbProperties.ConnectionStringName)]
    public interface IShippingDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}