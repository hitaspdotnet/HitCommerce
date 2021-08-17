using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Cms.EntityFrameworkCore
{
    [ConnectionStringName(CmsDbProperties.ConnectionStringName)]
    public interface ICmsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}