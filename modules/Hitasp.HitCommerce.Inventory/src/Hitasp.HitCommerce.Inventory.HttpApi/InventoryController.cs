using Hitasp.HitCommerce.Inventory.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Inventory
{
    public abstract class InventoryController : AbpController
    {
        protected InventoryController()
        {
            LocalizationResource = typeof(InventoryResource);
        }
    }
}
