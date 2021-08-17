using Hitasp.HitCommerce.Contacts.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Contacts
{
    public abstract class ContactsAppService : ApplicationService
    {
        protected ContactsAppService()
        {
            LocalizationResource = typeof(ContactsResource);
            ObjectMapperContext = typeof(ContactsApplicationModule);
        }
    }
}
