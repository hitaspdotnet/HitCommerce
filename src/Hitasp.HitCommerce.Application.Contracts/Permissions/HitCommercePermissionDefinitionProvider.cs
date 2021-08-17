using Hitasp.HitCommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Permissions
{
    public class HitCommercePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HitCommercePermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(HitCommercePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HitCommerceResource>(name);
        }
    }
}
