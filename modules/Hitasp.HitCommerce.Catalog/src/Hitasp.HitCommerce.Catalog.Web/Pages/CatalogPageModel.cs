using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Catalog.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CatalogPageModel : AbpPageModel
    {
        protected CatalogPageModel()
        {
            LocalizationResourceType = typeof(CatalogResource);
            ObjectMapperContext = typeof(CatalogWebModule);
        }
    }
}