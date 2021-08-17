using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
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
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule),
        typeof(AbpSettingManagementHttpApiClientModule)
    )]
    [DependsOn(typeof(ActivityLogHttpApiClientModule))]
    [DependsOn(typeof(CatalogHttpApiClientModule))]
    [DependsOn(typeof(CmsHttpApiClientModule))]
    [DependsOn(typeof(ContactsHttpApiClientModule))]
    [DependsOn(typeof(CoreHttpApiClientModule))]
    [DependsOn(typeof(InventoryHttpApiClientModule))]
    [DependsOn(typeof(OrdersHttpApiClientModule))]
    [DependsOn(typeof(PaymentsHttpApiClientModule))]
    [DependsOn(typeof(PricingHttpApiClientModule))]
    [DependsOn(typeof(ProductComparisonHttpApiClientModule))]
    [DependsOn(typeof(ProductRecentlyViewedHttpApiClientModule))]
    [DependsOn(typeof(SearchHttpApiClientModule))]
    public class HitCommerceHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HitCommerceApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
