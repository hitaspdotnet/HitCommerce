using Hitasp.HitCommerce.ProductComparison.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.ProductComparison.Permissions
{
    public class ProductComparisonPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProductComparisonPermissions.GroupName, L("Permission:ProductComparison"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductComparisonResource>(name);
        }
    }
}