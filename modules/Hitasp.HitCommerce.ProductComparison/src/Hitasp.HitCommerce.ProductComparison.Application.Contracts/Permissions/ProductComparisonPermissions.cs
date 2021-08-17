using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.ProductComparison.Permissions
{
    public class ProductComparisonPermissions
    {
        public const string GroupName = "ProductComparison";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductComparisonPermissions));
        }
    }
}