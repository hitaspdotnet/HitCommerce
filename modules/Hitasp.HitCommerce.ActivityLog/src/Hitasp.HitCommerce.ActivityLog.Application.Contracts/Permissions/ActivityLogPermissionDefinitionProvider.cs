using Hitasp.HitCommerce.ActivityLog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.ActivityLog.Permissions
{
    public class ActivityLogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ActivityLogPermissions.GroupName, L("Permission:ActivityLog"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ActivityLogResource>(name);
        }
    }
}