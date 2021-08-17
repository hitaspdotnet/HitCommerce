using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Orders.Permissions
{
    public class OrdersPermissions
    {
        public const string GroupName = "Orders";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrdersPermissions));
        }
    }
}