using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
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
using Hitasp.HitCommerce.ProductComparison;
using Hitasp.HitCommerce.ProductRecentlyViewed;
using Hitasp.HitCommerce.Search;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
        )]
    [DependsOn(typeof(ActivityLogApplicationModule))]
    [DependsOn(typeof(CatalogApplicationModule))]
    [DependsOn(typeof(CmsApplicationModule))]
    [DependsOn(typeof(ContactsApplicationModule))]
    [DependsOn(typeof(CoreApplicationModule))]
    [DependsOn(typeof(InventoryApplicationModule))]
    [DependsOn(typeof(OrdersApplicationModule))]
    [DependsOn(typeof(PaymentsApplicationModule))]
    [DependsOn(typeof(PricingApplicationModule))]
    [DependsOn(typeof(ProductComparisonApplicationModule))]
    [DependsOn(typeof(ProductRecentlyViewedApplicationModule))]
    [DependsOn(typeof(SearchApplicationModule))]
    public class HitCommerceApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HitCommerceApplicationModule>();
            });
        }
    }
}
