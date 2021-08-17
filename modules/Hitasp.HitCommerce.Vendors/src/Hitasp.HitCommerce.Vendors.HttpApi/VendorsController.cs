using Hitasp.HitCommerce.Vendors.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Vendors
{
    public abstract class VendorsController : AbpController
    {
        protected VendorsController()
        {
            LocalizationResource = typeof(VendorsResource);
        }
    }
}
