using Hitasp.HitCommerce.ProductRecentlyViewed.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    public abstract class ProductRecentlyViewedController : AbpController
    {
        protected ProductRecentlyViewedController()
        {
            LocalizationResource = typeof(ProductRecentlyViewedResource);
        }
    }
}
