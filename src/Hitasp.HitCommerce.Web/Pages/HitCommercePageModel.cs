using Hitasp.HitCommerce.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Web.Pages
{
    public abstract class HitCommercePageModel : AbpPageModel
    {
        protected HitCommercePageModel()
        {
            LocalizationResourceType = typeof(HitCommerceResource);
        }
    }
}