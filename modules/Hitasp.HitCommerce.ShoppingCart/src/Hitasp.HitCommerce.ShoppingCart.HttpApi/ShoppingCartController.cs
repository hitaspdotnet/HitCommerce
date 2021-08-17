using Hitasp.HitCommerce.ShoppingCart.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.ShoppingCart
{
    public abstract class ShoppingCartController : AbpController
    {
        protected ShoppingCartController()
        {
            LocalizationResource = typeof(ShoppingCartResource);
        }
    }
}
