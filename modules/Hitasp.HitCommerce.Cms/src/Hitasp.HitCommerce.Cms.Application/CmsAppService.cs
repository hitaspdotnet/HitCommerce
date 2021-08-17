using Hitasp.HitCommerce.Cms.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Cms
{
    public abstract class CmsAppService : ApplicationService
    {
        protected CmsAppService()
        {
            LocalizationResource = typeof(CmsResource);
            ObjectMapperContext = typeof(CmsApplicationModule);
        }
    }
}
