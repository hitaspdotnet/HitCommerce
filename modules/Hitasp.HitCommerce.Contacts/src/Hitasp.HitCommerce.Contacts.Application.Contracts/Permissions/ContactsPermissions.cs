using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Contacts.Permissions
{
    public class ContactsPermissions
    {
        public const string GroupName = "Contacts";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ContactsPermissions));
        }
    }
}