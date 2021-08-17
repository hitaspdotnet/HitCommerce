using Hitasp.HitCommerce.Pricing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Pricing.Permissions
{
    public class PricingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PricingPermissions.GroupName, L("Permission:Pricing"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PricingResource>(name);
        }
    }
}