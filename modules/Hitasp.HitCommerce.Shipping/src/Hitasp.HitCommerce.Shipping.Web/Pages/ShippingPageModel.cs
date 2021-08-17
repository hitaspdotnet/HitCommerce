using Hitasp.HitCommerce.Shipping.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Shipping.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ShippingPageModel : AbpPageModel
    {
        protected ShippingPageModel()
        {
            LocalizationResourceType = typeof(ShippingResource);
            ObjectMapperContext = typeof(ShippingWebModule);
        }
    }
}