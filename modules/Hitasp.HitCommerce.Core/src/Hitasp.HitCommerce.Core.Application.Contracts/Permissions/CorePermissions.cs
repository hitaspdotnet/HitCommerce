using Volo.Abp.Reflection;

namespace Hitasp.HitCommerce.Core.Permissions
{
    public class CorePermissions
    {
        public const string GroupName = "Core";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CorePermissions));
        }

        public class Countries
        {
            public const string Default = GroupName + ".Countries";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class StateOrProvinces
        {
            public const string Default = GroupName + ".StateOrProvinces";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Cities
        {
            public const string Default = GroupName + ".Cities";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}