using Hitasp.HitCommerce.Orders.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Orders
{
    public abstract class OrdersAppService : ApplicationService
    {
        protected OrdersAppService()
        {
            LocalizationResource = typeof(OrdersResource);
            ObjectMapperContext = typeof(OrdersApplicationModule);
        }
    }
}
