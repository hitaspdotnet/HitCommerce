using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Shipments.EntityFrameworkCore
{
    [ConnectionStringName(ShipmentsDbProperties.ConnectionStringName)]
    public interface IShipmentsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}