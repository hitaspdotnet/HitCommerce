using Hitasp.HitCommerce.ActivityLog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.ActivityLog.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ActivityLogPageModel : AbpPageModel
    {
        protected ActivityLogPageModel()
        {
            LocalizationResourceType = typeof(ActivityLogResource);
            ObjectMapperContext = typeof(ActivityLogWebModule);
        }
    }
}