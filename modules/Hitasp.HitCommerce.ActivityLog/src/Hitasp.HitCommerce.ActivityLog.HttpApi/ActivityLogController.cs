using Hitasp.HitCommerce.ActivityLog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.ActivityLog
{
    public abstract class ActivityLogController : AbpController
    {
        protected ActivityLogController()
        {
            LocalizationResource = typeof(ActivityLogResource);
        }
    }
}
