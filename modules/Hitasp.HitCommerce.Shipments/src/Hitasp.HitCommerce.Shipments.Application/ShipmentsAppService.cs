using Hitasp.HitCommerce.Shipments.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Shipments
{
    public abstract class ShipmentsAppService : ApplicationService
    {
        protected ShipmentsAppService()
        {
            LocalizationResource = typeof(ShipmentsResource);
            ObjectMapperContext = typeof(ShipmentsApplicationModule);
        }
    }
}
