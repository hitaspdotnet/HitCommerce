using Hitasp.HitCommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class HitCommerceController : AbpController
    {
        protected HitCommerceController()
        {
            LocalizationResource = typeof(HitCommerceResource);
        }
    }
}