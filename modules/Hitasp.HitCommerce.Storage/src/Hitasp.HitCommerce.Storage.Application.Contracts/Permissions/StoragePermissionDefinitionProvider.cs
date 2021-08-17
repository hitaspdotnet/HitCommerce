using Hitasp.HitCommerce.Storage.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Storage.Permissions
{
    public class StoragePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(StoragePermissions.GroupName, L("Permission:Storage"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<StorageResource>(name);
        }
    }
}