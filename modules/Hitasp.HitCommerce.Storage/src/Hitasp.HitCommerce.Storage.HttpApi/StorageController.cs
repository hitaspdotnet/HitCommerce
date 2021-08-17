using Hitasp.HitCommerce.Storage.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Storage
{
    public abstract class StorageController : AbpController
    {
        protected StorageController()
        {
            LocalizationResource = typeof(StorageResource);
        }
    }
}
