using Hitasp.HitCommerce.ProductComparison.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.ProductComparison
{
    public abstract class ProductComparisonAppService : ApplicationService
    {
        protected ProductComparisonAppService()
        {
            LocalizationResource = typeof(ProductComparisonResource);
            ObjectMapperContext = typeof(ProductComparisonApplicationModule);
        }
    }
}
