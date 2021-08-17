using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Search.Permissions
{
    public class SearchPermissions
    {
        public const string GroupName = "Search";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SearchPermissions));
        }
    }
}