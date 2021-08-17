using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Hitasp.HitCommerce.ActivityLog;
using Hitasp.HitCommerce.Catalog;
using Hitasp.HitCommerce.Cms;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceDomainSharedModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    [DependsOn(typeof(ActivityLogApplicationContractsModule))]
    [DependsOn(typeof(CatalogApplicationContractsModule))]
    [DependsOn(typeof(CmsApplicationContractsModule))]
    public class HitCommerceApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceDtoExtensions.Configure();
        }
    }
}
