using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.ProductComparison.Web.Menus
{
    public class ProductComparisonMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(ProductComparisonMenus.Prefix, displayName: "ProductComparison", "~/ProductComparison", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}