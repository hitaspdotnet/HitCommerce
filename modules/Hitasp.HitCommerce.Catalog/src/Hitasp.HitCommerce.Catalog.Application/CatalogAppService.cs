using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog
{
    public abstract class CatalogAppService : ApplicationService
    {
        protected CatalogAppService()
        {
            LocalizationResource = typeof(CatalogResource);
            ObjectMapperContext = typeof(CatalogApplicationModule);
        }
    }
}
