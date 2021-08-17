using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Payments.Permissions
{
    public class PaymentsPermissions
    {
        public const string GroupName = "Payments";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(PaymentsPermissions));
        }
    }
}