using Hitasp.HitCommerce.Shipping.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Shipping
{
    public abstract class ShippingController : AbpController
    {
        protected ShippingController()
        {
            LocalizationResource = typeof(ShippingResource);
        }
    }
}
