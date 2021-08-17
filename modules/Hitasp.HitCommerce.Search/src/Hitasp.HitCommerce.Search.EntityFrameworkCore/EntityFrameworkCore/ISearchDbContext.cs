using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Search.EntityFrameworkCore
{
    [ConnectionStringName(SearchDbProperties.ConnectionStringName)]
    public interface ISearchDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}