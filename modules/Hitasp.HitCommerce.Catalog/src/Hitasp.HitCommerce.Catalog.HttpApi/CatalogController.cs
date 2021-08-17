using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Catalog
{
    public abstract class CatalogController : AbpController
    {
        protected CatalogController()
        {
            LocalizationResource = typeof(CatalogResource);
        }
    }
}
