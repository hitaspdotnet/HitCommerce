using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.ActivityLog.Web.Menus
{
    public class ActivityLogMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(ActivityLogMenus.Prefix, displayName: "ActivityLog", "~/ActivityLog", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}