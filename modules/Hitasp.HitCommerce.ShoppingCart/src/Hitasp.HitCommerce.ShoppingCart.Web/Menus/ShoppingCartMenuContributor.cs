using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.ShoppingCart.Web.Menus
{
    public class ShoppingCartMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(ShoppingCartMenus.Prefix, displayName: "ShoppingCart", "~/ShoppingCart", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}