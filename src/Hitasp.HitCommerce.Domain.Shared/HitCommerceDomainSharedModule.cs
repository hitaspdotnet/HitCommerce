using Hitasp.HitCommerce.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Hitasp.HitCommerce.ActivityLog;
using Hitasp.HitCommerce.Catalog;
using Hitasp.HitCommerce.Cms;
using Hitasp.HitCommerce.Contacts;
using Hitasp.HitCommerce.Core;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    [DependsOn(typeof(ActivityLogDomainSharedModule))]
    [DependsOn(typeof(CatalogDomainSharedModule))]
    [DependsOn(typeof(CmsDomainSharedModule))]
    [DependsOn(typeof(ContactsDomainSharedModule))]
    [DependsOn(typeof(CoreDomainSharedModule))]
    public class HitCommerceDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceGlobalFeatureConfigurator.Configure();
            HitCommerceModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HitCommerceDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<HitCommerceResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/HitCommerce");

                options.DefaultResourceType = typeof(HitCommerceResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("HitCommerce", typeof(HitCommerceResource));
            });
        }
    }
}
