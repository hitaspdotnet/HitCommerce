using Hitasp.HitCommerce.Payments.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Payments
{
    public abstract class PaymentsController : AbpController
    {
        protected PaymentsController()
        {
            LocalizationResource = typeof(PaymentsResource);
        }
    }
}
