using Hitasp.HitCommerce.Core.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Core
{
    public abstract class CoreController : AbpController
    {
        protected CoreController()
        {
            LocalizationResource = typeof(CoreResource);
        }
    }
}
