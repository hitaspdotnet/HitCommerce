﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitCommerce.Shipments.Localization;
using Hitasp.HitCommerce.Shipments.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Hitasp.HitCommerce.Shipments.Permissions;

namespace Hitasp.HitCommerce.Shipments.Web
{
    [DependsOn(
        typeof(ShipmentsHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ShipmentsWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(ShipmentsResource), typeof(ShipmentsWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ShipmentsWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new ShipmentsMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ShipmentsWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<ShipmentsWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ShipmentsWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
