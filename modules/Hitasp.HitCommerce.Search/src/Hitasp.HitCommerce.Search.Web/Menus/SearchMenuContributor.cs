using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.Search.Web.Menus
{
    public class SearchMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(SearchMenus.Prefix, displayName: "Search", "~/Search", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}