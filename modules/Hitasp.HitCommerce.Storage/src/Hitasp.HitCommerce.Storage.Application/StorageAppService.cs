using Hitasp.HitCommerce.Storage.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Storage
{
    public abstract class StorageAppService : ApplicationService
    {
        protected StorageAppService()
        {
            LocalizationResource = typeof(StorageResource);
            ObjectMapperContext = typeof(StorageApplicationModule);
        }
    }
}
