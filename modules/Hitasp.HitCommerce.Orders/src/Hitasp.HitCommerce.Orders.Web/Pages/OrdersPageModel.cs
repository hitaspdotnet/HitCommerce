using Hitasp.HitCommerce.Orders.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Orders.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class OrdersPageModel : AbpPageModel
    {
        protected OrdersPageModel()
        {
            LocalizationResourceType = typeof(OrdersResource);
            ObjectMapperContext = typeof(OrdersWebModule);
        }
    }
}