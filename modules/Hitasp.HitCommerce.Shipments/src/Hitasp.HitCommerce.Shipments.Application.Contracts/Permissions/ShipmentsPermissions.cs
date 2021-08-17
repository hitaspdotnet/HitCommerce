using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Shipments.Permissions
{
    public class ShipmentsPermissions
    {
        public const string GroupName = "Shipments";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ShipmentsPermissions));
        }
    }
}