using Hitasp.HitCommerce.Contacts.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Contacts
{
    public abstract class ContactsController : AbpController
    {
        protected ContactsController()
        {
            LocalizationResource = typeof(ContactsResource);
        }
    }
}
