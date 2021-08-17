using Hitasp.HitCommerce.Pricing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Pricing
{
    public abstract class PricingController : AbpController
    {
        protected PricingController()
        {
            LocalizationResource = typeof(PricingResource);
        }
    }
}
