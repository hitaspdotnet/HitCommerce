using Hitasp.HitCommerce.Cms.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Cms.Permissions
{
    public class CmsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CmsPermissions.GroupName, L("Permission:Cms"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsResource>(name);
        }
    }
}