using System.Threading.Tasks;

namespace Hitasp.HitCommerce.Data
{
    public interface IHitCommerceDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}