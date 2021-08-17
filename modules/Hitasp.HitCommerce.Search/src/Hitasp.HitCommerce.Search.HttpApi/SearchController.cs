using Hitasp.HitCommerce.Search.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Search
{
    public abstract class SearchController : AbpController
    {
        protected SearchController()
        {
            LocalizationResource = typeof(SearchResource);
        }
    }
}
