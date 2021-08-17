using Hitasp.HitCommerce.Core.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Core.Permissions
{
    public class CorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CorePermissions.GroupName, L("Permission:Core"));

            var countryPermission = myGroup.AddPermission(CorePermissions.Countries.Default, L("Permission:Countries"));
            countryPermission.AddChild(CorePermissions.Countries.Create, L("Permission:Create"));
            countryPermission.AddChild(CorePermissions.Countries.Edit, L("Permission:Edit"));
            countryPermission.AddChild(CorePermissions.Countries.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CoreResource>(name);
        }
    }
}