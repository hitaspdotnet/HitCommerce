using Hitasp.HitCommerce.Vendors.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Vendors.Permissions
{
    public class VendorsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(VendorsPermissions.GroupName, L("Permission:Vendors"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<VendorsResource>(name);
        }
    }
}