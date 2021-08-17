using Localization.Resources.AbpUi;
using Hitasp.HitCommerce.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Hitasp.HitCommerce.ActivityLog;
using Hitasp.HitCommerce.Catalog;
using Hitasp.HitCommerce.Cms;
using Hitasp.HitCommerce.Contacts;
using Hitasp.HitCommerce.Core;
using Hitasp.HitCommerce.Inventory;
using Hitasp.HitCommerce.Orders;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpSettingManagementHttpApiModule)
        )]
    [DependsOn(typeof(ActivityLogHttpApiModule))]
    [DependsOn(typeof(CatalogHttpApiModule))]
    [DependsOn(typeof(CmsHttpApiModule))]
    [DependsOn(typeof(ContactsHttpApiModule))]
    [DependsOn(typeof(CoreHttpApiModule))]
    [DependsOn(typeof(InventoryHttpApiModule))]
    [DependsOn(typeof(OrdersHttpApiModule))]
    public class HitCommerceHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HitCommerceResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
