using Hitasp.HitCommerce.Vendors.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Vendors.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class VendorsPageModel : AbpPageModel
    {
        protected VendorsPageModel()
        {
            LocalizationResourceType = typeof(VendorsResource);
            ObjectMapperContext = typeof(VendorsWebModule);
        }
    }
}