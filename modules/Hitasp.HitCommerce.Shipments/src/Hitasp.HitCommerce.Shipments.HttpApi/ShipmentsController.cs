using Hitasp.HitCommerce.Shipments.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Shipments
{
    public abstract class ShipmentsController : AbpController
    {
        protected ShipmentsController()
        {
            LocalizationResource = typeof(ShipmentsResource);
        }
    }
}
