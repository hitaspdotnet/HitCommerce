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

            var stateOrProvincePermission = myGroup.AddPermission(CorePermissions.StateOrProvinces.Default, L("Permission:StateOrProvinces"));
            stateOrProvincePermission.AddChild(CorePermissions.StateOrProvinces.Create, L("Permission:Create"));
            stateOrProvincePermission.AddChild(CorePermissions.StateOrProvinces.Edit, L("Permission:Edit"));
            stateOrProvincePermission.AddChild(CorePermissions.StateOrProvinces.Delete, L("Permission:Delete"));

            var cityPermission = myGroup.AddPermission(CorePermissions.Cities.Default, L("Permission:Cities"));
            cityPermission.AddChild(CorePermissions.Cities.Create, L("Permission:Create"));
            cityPermission.AddChild(CorePermissions.Cities.Edit, L("Permission:Edit"));
            cityPermission.AddChild(CorePermissions.Cities.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CoreResource>(name);
        }
    }
}