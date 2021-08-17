using Hitasp.HitCommerce.Inventory.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Inventory
{
    public abstract class InventoryAppService : ApplicationService
    {
        protected InventoryAppService()
        {
            LocalizationResource = typeof(InventoryResource);
            ObjectMapperContext = typeof(InventoryApplicationModule);
        }
    }
}
