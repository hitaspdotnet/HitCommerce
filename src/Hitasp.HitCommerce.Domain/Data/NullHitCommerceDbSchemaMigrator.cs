using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Hitasp.HitCommerce.Data
{
    /* This is used if database provider does't define
     * IHitCommerceDbSchemaMigrator implementation.
     */
    public class NullHitCommerceDbSchemaMigrator : IHitCommerceDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}