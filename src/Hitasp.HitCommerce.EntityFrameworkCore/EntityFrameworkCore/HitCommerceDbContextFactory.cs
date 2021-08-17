using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class HitCommerceDbContextFactory : IDesignTimeDbContextFactory<HitCommerceDbContext>
    {
        public HitCommerceDbContext CreateDbContext(string[] args)
        {
            HitCommerceEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HitCommerceDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new HitCommerceDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Hitasp.HitCommerce.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}