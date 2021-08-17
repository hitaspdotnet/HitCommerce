using Hitasp.HitCommerce.Storage.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Storage.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class StoragePageModel : AbpPageModel
    {
        protected StoragePageModel()
        {
            LocalizationResourceType = typeof(StorageResource);
            ObjectMapperContext = typeof(StorageWebModule);
        }
    }
}