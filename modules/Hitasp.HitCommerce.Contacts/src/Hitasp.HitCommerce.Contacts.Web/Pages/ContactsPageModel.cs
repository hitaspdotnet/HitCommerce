using Hitasp.HitCommerce.Contacts.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.HitCommerce.Contacts.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ContactsPageModel : AbpPageModel
    {
        protected ContactsPageModel()
        {
            LocalizationResourceType = typeof(ContactsResource);
            ObjectMapperContext = typeof(ContactsWebModule);
        }
    }
}