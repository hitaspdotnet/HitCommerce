using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Vendors.EntityFrameworkCore
{
    [ConnectionStringName(VendorsDbProperties.ConnectionStringName)]
    public interface IVendorsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}