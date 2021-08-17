using Hitasp.HitCommerce.Tax.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Tax
{
    public abstract class TaxAppService : ApplicationService
    {
        protected TaxAppService()
        {
            LocalizationResource = typeof(TaxResource);
            ObjectMapperContext = typeof(TaxApplicationModule);
        }
    }
}
