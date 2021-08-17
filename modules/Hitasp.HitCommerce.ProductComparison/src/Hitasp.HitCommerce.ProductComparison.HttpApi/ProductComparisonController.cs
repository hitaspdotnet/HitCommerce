using Hitasp.HitCommerce.ProductComparison.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.ProductComparison
{
    public abstract class ProductComparisonController : AbpController
    {
        protected ProductComparisonController()
        {
            LocalizationResource = typeof(ProductComparisonResource);
        }
    }
}
