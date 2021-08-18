using Hitasp.HitCommerce.Core.Addresses;
using Hitasp.HitCommerce.Core.Districts;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Countries;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Core.EntityFrameworkCore
{
    [ConnectionStringName(CoreDbProperties.ConnectionStringName)]
    public interface ICoreDbContext : IEfCoreDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<StateOrProvince> StateOrProvinces { get; set; }
        DbSet<Country> Countries { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}