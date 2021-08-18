using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitCommerce.Core.Localization;
using Hitasp.HitCommerce.Core.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Hitasp.HitCommerce.Core.Permissions;

namespace Hitasp.HitCommerce.Core.Web
{
    [DependsOn(
        typeof(CoreHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class CoreWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(CoreResource), typeof(CoreWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CoreWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CoreMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CoreWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<CoreWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CoreWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
                options.Conventions.AuthorizePage("/Countries/Index", CorePermissions.Countries.Default);
                options.Conventions.AuthorizePage("/StateOrProvinces/Index", CorePermissions.StateOrProvinces.Default);
                options.Conventions.AuthorizePage("/Cities/Index", CorePermissions.Cities.Default);
                options.Conventions.AuthorizePage("/Districts/Index", CorePermissions.Districts.Default);
            });
        }
    }
}