using Hitasp.HitCommerce.Payments.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Payments
{
    public abstract class PaymentsAppService : ApplicationService
    {
        protected PaymentsAppService()
        {
            LocalizationResource = typeof(PaymentsResource);
            ObjectMapperContext = typeof(PaymentsApplicationModule);
        }
    }
}
