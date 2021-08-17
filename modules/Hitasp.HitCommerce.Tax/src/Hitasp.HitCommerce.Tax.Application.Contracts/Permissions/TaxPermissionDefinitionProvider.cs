using Hitasp.HitCommerce.Tax.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Tax.Permissions
{
    public class TaxPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TaxPermissions.GroupName, L("Permission:Tax"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TaxResource>(name);
        }
    }
}