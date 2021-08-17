using Hitasp.HitCommerce.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.PublicWeb.Pages
{
    public abstract class HitCommercePublicPageModel : AbpPageModel
    {
        protected HitCommercePublicPageModel()
        {
            LocalizationResourceType = typeof(HitCommerceResource);
        }
    }
}