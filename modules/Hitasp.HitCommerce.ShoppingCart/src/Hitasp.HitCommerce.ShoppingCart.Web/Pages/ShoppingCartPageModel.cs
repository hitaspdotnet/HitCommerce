using Hitasp.HitCommerce.ShoppingCart.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.ShoppingCart.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ShoppingCartPageModel : AbpPageModel
    {
        protected ShoppingCartPageModel()
        {
            LocalizationResourceType = typeof(ShoppingCartResource);
            ObjectMapperContext = typeof(ShoppingCartWebModule);
        }
    }
}