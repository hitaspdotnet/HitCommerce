using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.Permissions
{
    public class ProductRecentlyViewedPermissions
    {
        public const string GroupName = "ProductRecentlyViewed";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductRecentlyViewedPermissions));
        }
    }
}