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
using Hitasp.HitCommerce.Contacts;
using Hitasp.HitCommerce.Core;
using Hitasp.HitCommerce.Inventory;
using Hitasp.HitCommerce.Orders;
using Hitasp.HitCommerce.Payments;
using Hitasp.HitCommerce.Pricing;

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
    [DependsOn(typeof(ContactsApplicationContractsModule))]
    [DependsOn(typeof(CoreApplicationContractsModule))]
    [DependsOn(typeof(InventoryApplicationContractsModule))]
    [DependsOn(typeof(OrdersApplicationContractsModule))]
    [DependsOn(typeof(PaymentsApplicationContractsModule))]
    [DependsOn(typeof(PricingApplicationContractsModule))]
    public class HitCommerceApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceDtoExtensions.Configure();
        }
    }
}
