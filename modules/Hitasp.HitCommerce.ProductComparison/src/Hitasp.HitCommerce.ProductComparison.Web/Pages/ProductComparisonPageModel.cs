using Hitasp.HitCommerce.ProductComparison.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.ProductComparison.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ProductComparisonPageModel : AbpPageModel
    {
        protected ProductComparisonPageModel()
        {
            LocalizationResourceType = typeof(ProductComparisonResource);
            ObjectMapperContext = typeof(ProductComparisonWebModule);
        }
    }
}