using Hitasp.HitCommerce.Core.Permissions;
using Hitasp.HitCommerce.Core.Localization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Hitasp.HitCommerce.Core.Web.Menus
{
    public class CoreMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }

            var moduleMenu = AddModuleMenuItem(context);
            await AddMenuItemCountries(context, moduleMenu);

            await AddMenuItemStateOrProvinces(context, moduleMenu);

            await AddMenuItemCities(context, moduleMenu);

            await AddMenuItemDistricts(context, moduleMenu);

            await AddMenuItemAddresses(context, moduleMenu);
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(CoreMenus.Prefix, displayName: "Core", "~/Core", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }

        private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
        {
            var moduleMenu = new ApplicationMenuItem(
                CoreMenus.Prefix,
                context.GetLocalizer<CoreResource>()["Menu:Core"],
                icon: "fa fa-folder"
            );

            context.Menu.Items.AddIfNotContains(moduleMenu);
            return moduleMenu;
        }
        private static async Task AddMenuItemCountries(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
        {
            parentMenu.AddItem(
                new ApplicationMenuItem(
                    Menus.CoreMenus.Countries,
                    context.GetLocalizer<CoreResource>()["Menu:Countries"],
                    "/Core/Countries",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: CorePermissions.Countries.Default
                )
            );
        }

        private static async Task AddMenuItemStateOrProvinces(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
        {
            parentMenu.AddItem(
                new ApplicationMenuItem(
                    Menus.CoreMenus.StateOrProvinces,
                    context.GetLocalizer<CoreResource>()["Menu:StateOrProvinces"],
                    "/Core/StateOrProvinces",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: CorePermissions.StateOrProvinces.Default
                )
            );
        }

        private static async Task AddMenuItemCities(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
        {
            parentMenu.AddItem(
                new ApplicationMenuItem(
                    Menus.CoreMenus.Cities,
                    context.GetLocalizer<CoreResource>()["Menu:Cities"],
                    "/Core/Cities",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: CorePermissions.Cities.Default
                )
            );
        }

        private static async Task AddMenuItemDistricts(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
        {
            parentMenu.AddItem(
                new ApplicationMenuItem(
                    Menus.CoreMenus.Districts,
                    context.GetLocalizer<CoreResource>()["Menu:Districts"],
                    "/Core/Districts",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: CorePermissions.Districts.Default
                )
            );
        }

        private static async Task AddMenuItemAddresses(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
        {
            parentMenu.AddItem(
                new ApplicationMenuItem(
                    Menus.CoreMenus.Addresses,
                    context.GetLocalizer<CoreResource>()["Menu:Addresses"],
                    "/Core/Addresses",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: CorePermissions.Addresses.Default
                )
            );
        }
    }
}