using Hitasp.HitCommerce.ProductRecentlyViewed.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.Permissions
{
    public class ProductRecentlyViewedPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProductRecentlyViewedPermissions.GroupName, L("Permission:ProductRecentlyViewed"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductRecentlyViewedResource>(name);
        }
    }
}