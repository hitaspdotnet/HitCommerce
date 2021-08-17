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
using Hitasp.HitCommerce.Payments;
using Hitasp.HitCommerce.Pricing;
using Hitasp.HitCommerce.ProductComparison;
using Hitasp.HitCommerce.ProductRecentlyViewed;
using Hitasp.HitCommerce.Search;
using Hitasp.HitCommerce.Shipments;
using Hitasp.HitCommerce.Shipping;
using Hitasp.HitCommerce.ShoppingCart;
using Hitasp.HitCommerce.Storage;
using Hitasp.HitCommerce.Tax;
using Hitasp.HitCommerce.Vendors;

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
    [DependsOn(typeof(PaymentsHttpApiModule))]
    [DependsOn(typeof(PricingHttpApiModule))]
    [DependsOn(typeof(ProductComparisonHttpApiModule))]
    [DependsOn(typeof(ProductRecentlyViewedHttpApiModule))]
    [DependsOn(typeof(SearchHttpApiModule))]
    [DependsOn(typeof(ShipmentsHttpApiModule))]
    [DependsOn(typeof(ShippingHttpApiModule))]
    [DependsOn(typeof(ShoppingCartHttpApiModule))]
    [DependsOn(typeof(StorageHttpApiModule))]
    [DependsOn(typeof(TaxHttpApiModule))]
    [DependsOn(typeof(VendorsHttpApiModule))]
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