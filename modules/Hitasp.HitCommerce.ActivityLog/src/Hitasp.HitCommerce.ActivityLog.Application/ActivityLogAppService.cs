using Hitasp.HitCommerce.ActivityLog.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.ActivityLog
{
    public abstract class ActivityLogAppService : ApplicationService
    {
        protected ActivityLogAppService()
        {
            LocalizationResource = typeof(ActivityLogResource);
            ObjectMapperContext = typeof(ActivityLogApplicationModule);
        }
    }
}
