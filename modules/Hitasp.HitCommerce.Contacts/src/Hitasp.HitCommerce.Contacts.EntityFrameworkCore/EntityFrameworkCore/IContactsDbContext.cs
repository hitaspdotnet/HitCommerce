using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Contacts.EntityFrameworkCore
{
    [ConnectionStringName(ContactsDbProperties.ConnectionStringName)]
    public interface IContactsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}