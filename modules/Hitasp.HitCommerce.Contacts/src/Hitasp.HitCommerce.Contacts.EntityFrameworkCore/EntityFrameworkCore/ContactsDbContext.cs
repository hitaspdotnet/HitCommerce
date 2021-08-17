using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Contacts.EntityFrameworkCore
{
    [ConnectionStringName(ContactsDbProperties.ConnectionStringName)]
    public class ContactsDbContext : AbpDbContext<ContactsDbContext>, IContactsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureContacts();
        }
    }
}