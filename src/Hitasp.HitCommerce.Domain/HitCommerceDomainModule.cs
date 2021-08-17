using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hitasp.HitCommerce.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
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

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpTenantManagementDomainModule),
        typeof(AbpEmailingModule)
    )]
    [DependsOn(typeof(ActivityLogDomainModule))]
    [DependsOn(typeof(CatalogDomainModule))]
    [DependsOn(typeof(CmsDomainModule))]
    [DependsOn(typeof(ContactsDomainModule))]
    [DependsOn(typeof(CoreDomainModule))]
    [DependsOn(typeof(InventoryDomainModule))]
    [DependsOn(typeof(OrdersDomainModule))]
    [DependsOn(typeof(PaymentsDomainModule))]
    [DependsOn(typeof(PricingDomainModule))]
    [DependsOn(typeof(ProductComparisonDomainModule))]
    [DependsOn(typeof(ProductRecentlyViewedDomainModule))]
    [DependsOn(typeof(SearchDomainModule))]
    [DependsOn(typeof(ShipmentsDomainModule))]
    [DependsOn(typeof(ShippingDomainModule))]
    [DependsOn(typeof(ShoppingCartDomainModule))]
    [DependsOn(typeof(StorageDomainModule))]
    [DependsOn(typeof(TaxDomainModule))]
    public class HitCommerceDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
