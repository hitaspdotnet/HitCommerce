using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Cms.Permissions
{
    public class CmsPermissions
    {
        public const string GroupName = "Cms";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsPermissions));
        }
    }
}