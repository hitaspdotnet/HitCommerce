using Hitasp.HitCommerce.Cms.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Cms
{
    public abstract class CmsController : AbpController
    {
        protected CmsController()
        {
            LocalizationResource = typeof(CmsResource);
        }
    }
}
