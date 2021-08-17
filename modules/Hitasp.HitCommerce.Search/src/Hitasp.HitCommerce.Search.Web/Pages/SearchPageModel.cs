using Hitasp.HitCommerce.Search.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Search.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class SearchPageModel : AbpPageModel
    {
        protected SearchPageModel()
        {
            LocalizationResourceType = typeof(SearchResource);
            ObjectMapperContext = typeof(SearchWebModule);
        }
    }
}