using Hitasp.HitCommerce.ShoppingCart.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.ShoppingCart.Permissions
{
    public class ShoppingCartPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ShoppingCartPermissions.GroupName, L("Permission:ShoppingCart"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ShoppingCartResource>(name);
        }
    }
}