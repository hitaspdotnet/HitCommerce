using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitCommerce.Data;
using Volo.Abp.DependencyInjection;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    public class EntityFrameworkCoreHitCommerceDbSchemaMigrator
        : IHitCommerceDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHitCommerceDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HitCommerceDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HitCommerceDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
