using Hitasp.HitCommerce.ProductRecentlyViewed.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    public abstract class ProductRecentlyViewedAppService : ApplicationService
    {
        protected ProductRecentlyViewedAppService()
        {
            LocalizationResource = typeof(ProductRecentlyViewedResource);
            ObjectMapperContext = typeof(ProductRecentlyViewedApplicationModule);
        }
    }
}
