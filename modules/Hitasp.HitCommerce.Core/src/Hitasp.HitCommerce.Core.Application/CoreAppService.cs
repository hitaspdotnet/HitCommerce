using Hitasp.HitCommerce.Core.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Core
{
    public abstract class CoreAppService : ApplicationService
    {
        protected CoreAppService()
        {
            LocalizationResource = typeof(CoreResource);
            ObjectMapperContext = typeof(CoreApplicationModule);
        }
    }
}
