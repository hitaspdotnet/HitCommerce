using Hitasp.HitCommerce.Pricing.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Pricing
{
    public abstract class PricingAppService : ApplicationService
    {
        protected PricingAppService()
        {
            LocalizationResource = typeof(PricingResource);
            ObjectMapperContext = typeof(PricingApplicationModule);
        }
    }
}
