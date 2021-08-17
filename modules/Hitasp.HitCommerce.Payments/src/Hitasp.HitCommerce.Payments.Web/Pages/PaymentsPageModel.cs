using Hitasp.HitCommerce.Payments.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Payments.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PaymentsPageModel : AbpPageModel
    {
        protected PaymentsPageModel()
        {
            LocalizationResourceType = typeof(PaymentsResource);
            ObjectMapperContext = typeof(PaymentsWebModule);
        }
    }
}