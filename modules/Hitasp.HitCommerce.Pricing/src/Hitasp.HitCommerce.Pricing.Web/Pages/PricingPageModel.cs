using Hitasp.HitCommerce.Pricing.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Pricing.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PricingPageModel : AbpPageModel
    {
        protected PricingPageModel()
        {
            LocalizationResourceType = typeof(PricingResource);
            ObjectMapperContext = typeof(PricingWebModule);
        }
    }
}