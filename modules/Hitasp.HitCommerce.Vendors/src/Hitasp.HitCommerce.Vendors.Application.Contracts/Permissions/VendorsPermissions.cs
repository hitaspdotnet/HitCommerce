using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Vendors.Permissions
{
    public class VendorsPermissions
    {
        public const string GroupName = "Vendors";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(VendorsPermissions));
        }
    }
}