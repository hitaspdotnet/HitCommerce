using Hitasp.HitCommerce.ShoppingCart.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.ShoppingCart
{
    public abstract class ShoppingCartAppService : ApplicationService
    {
        protected ShoppingCartAppService()
        {
            LocalizationResource = typeof(ShoppingCartResource);
            ObjectMapperContext = typeof(ShoppingCartApplicationModule);
        }
    }
}
