using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Pricing.Permissions
{
    public class PricingPermissions
    {
        public const string GroupName = "Pricing";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(PricingPermissions));
        }
    }
}