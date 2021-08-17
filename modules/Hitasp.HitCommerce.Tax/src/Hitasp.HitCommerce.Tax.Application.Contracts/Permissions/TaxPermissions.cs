using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Tax.Permissions
{
    public class TaxPermissions
    {
        public const string GroupName = "Tax";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(TaxPermissions));
        }
    }
}