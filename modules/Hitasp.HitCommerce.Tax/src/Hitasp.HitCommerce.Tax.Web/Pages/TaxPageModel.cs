using Hitasp.HitCommerce.Tax.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Tax.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class TaxPageModel : AbpPageModel
    {
        protected TaxPageModel()
        {
            LocalizationResourceType = typeof(TaxResource);
            ObjectMapperContext = typeof(TaxWebModule);
        }
    }
}