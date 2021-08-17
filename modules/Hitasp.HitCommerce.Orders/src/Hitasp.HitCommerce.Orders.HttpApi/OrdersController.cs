using Hitasp.HitCommerce.Orders.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hitasp.HitCommerce.Orders
{
    public abstract class OrdersController : AbpController
    {
        protected OrdersController()
        {
            LocalizationResource = typeof(OrdersResource);
        }
    }
}
