using Hitasp.HitCommerce.ProductRecentlyViewed.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ProductRecentlyViewedPageModel : AbpPageModel
    {
        protected ProductRecentlyViewedPageModel()
        {
            LocalizationResourceType = typeof(ProductRecentlyViewedResource);
            ObjectMapperContext = typeof(ProductRecentlyViewedWebModule);
        }
    }
}