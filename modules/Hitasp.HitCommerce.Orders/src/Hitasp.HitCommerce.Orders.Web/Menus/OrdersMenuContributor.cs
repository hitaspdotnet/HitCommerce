using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.Orders.Web.Menus
{
    public class OrdersMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(OrdersMenus.Prefix, displayName: "Orders", "~/Orders", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}