using Hitasp.HitCommerce.Tax.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Tax
{
    public abstract class TaxController : AbpController
    {
        protected TaxController()
        {
            LocalizationResource = typeof(TaxResource);
        }
    }
}
