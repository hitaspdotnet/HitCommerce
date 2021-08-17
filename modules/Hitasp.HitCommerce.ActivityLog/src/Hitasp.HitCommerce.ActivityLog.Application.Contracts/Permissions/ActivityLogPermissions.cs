using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.ActivityLog.Permissions
{
    public class ActivityLogPermissions
    {
        public const string GroupName = "ActivityLog";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ActivityLogPermissions));
        }
    }
}