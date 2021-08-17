using Hitasp.HitCommerce.Search.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Search
{
    public abstract class SearchAppService : ApplicationService
    {
        protected SearchAppService()
        {
            LocalizationResource = typeof(SearchResource);
            ObjectMapperContext = typeof(SearchApplicationModule);
        }
    }
}
