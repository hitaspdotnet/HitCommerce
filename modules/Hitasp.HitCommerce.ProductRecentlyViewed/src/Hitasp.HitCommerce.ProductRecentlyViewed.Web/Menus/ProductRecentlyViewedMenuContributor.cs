using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.Web.Menus
{
    public class ProductRecentlyViewedMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(ProductRecentlyViewedMenus.Prefix, displayName: "ProductRecentlyViewed", "~/ProductRecentlyViewed", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}