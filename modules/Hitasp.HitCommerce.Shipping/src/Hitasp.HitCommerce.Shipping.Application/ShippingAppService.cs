using Hitasp.HitCommerce.Shipping.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Shipping
{
    public abstract class ShippingAppService : ApplicationService
    {
        protected ShippingAppService()
        {
            LocalizationResource = typeof(ShippingResource);
            ObjectMapperContext = typeof(ShippingApplicationModule);
        }
    }
}
