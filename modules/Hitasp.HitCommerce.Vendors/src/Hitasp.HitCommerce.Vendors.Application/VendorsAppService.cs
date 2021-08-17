using Hitasp.HitCommerce.Vendors.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Vendors
{
    public abstract class VendorsAppService : ApplicationService
    {
        protected VendorsAppService()
        {
            LocalizationResource = typeof(VendorsResource);
            ObjectMapperContext = typeof(VendorsApplicationModule);
        }
    }
}
