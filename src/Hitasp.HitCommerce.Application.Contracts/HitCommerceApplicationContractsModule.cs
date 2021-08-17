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
using Hitasp.HitCommerce.ProductComparison;
using Hitasp.HitCommerce.ProductRecentlyViewed;
using Hitasp.HitCommerce.Search;
using Hitasp.HitCommerce.Shipments;
using Hitasp.HitCommerce.Shipping;
using Hitasp.HitCommerce.ShoppingCart;
using Hitasp.HitCommerce.Storage;

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
    [DependsOn(typeof(ProductComparisonApplicationContractsModule))]
    [DependsOn(typeof(ProductRecentlyViewedApplicationContractsModule))]
    [DependsOn(typeof(SearchApplicationContractsModule))]
    [DependsOn(typeof(ShipmentsApplicationContractsModule))]
    [DependsOn(typeof(ShippingApplicationContractsModule))]
    [DependsOn(typeof(ShoppingCartApplicationContractsModule))]
    [DependsOn(typeof(StorageApplicationContractsModule))]
    public class HitCommerceApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceDtoExtensions.Configure();
        }
    }
}
