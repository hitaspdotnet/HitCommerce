using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Catalog.Permissions
{
    public class CatalogPermissions
    {
        public const string GroupName = "Catalog";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CatalogPermissions));
        }
    }
}