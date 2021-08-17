using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Shipping.Permissions
{
    public class ShippingPermissions
    {
        public const string GroupName = "Shipping";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ShippingPermissions));
        }
    }
}