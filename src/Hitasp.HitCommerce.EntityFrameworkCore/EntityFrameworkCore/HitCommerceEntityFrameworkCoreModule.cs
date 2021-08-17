using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Hitasp.HitCommerce.ActivityLog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Cms.EntityFrameworkCore;
using Hitasp.HitCommerce.Contacts.EntityFrameworkCore;
using Hitasp.HitCommerce.Core.EntityFrameworkCore;
using Hitasp.HitCommerce.Inventory.EntityFrameworkCore;
using Hitasp.HitCommerce.Orders.EntityFrameworkCore;
using Hitasp.HitCommerce.Payments.EntityFrameworkCore;
using Hitasp.HitCommerce.Pricing.EntityFrameworkCore;
using Hitasp.HitCommerce.ProductComparison.EntityFrameworkCore;
using Hitasp.HitCommerce.ProductRecentlyViewed.EntityFrameworkCore;
using Hitasp.HitCommerce.Search.EntityFrameworkCore;
using Hitasp.HitCommerce.Shipments.EntityFrameworkCore;
using Hitasp.HitCommerce.Shipping.EntityFrameworkCore;
using Hitasp.HitCommerce.ShoppingCart.EntityFrameworkCore;
using Hitasp.HitCommerce.Storage.EntityFrameworkCore;
using Hitasp.HitCommerce.Tax.EntityFrameworkCore;
using Hitasp.HitCommerce.Vendors.EntityFrameworkCore;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule)
        )]
    [DependsOn(typeof(ActivityLogEntityFrameworkCoreModule))]
    [DependsOn(typeof(CatalogEntityFrameworkCoreModule))]
    [DependsOn(typeof(CmsEntityFrameworkCoreModule))]
    [DependsOn(typeof(ContactsEntityFrameworkCoreModule))]
    [DependsOn(typeof(CoreEntityFrameworkCoreModule))]
    [DependsOn(typeof(InventoryEntityFrameworkCoreModule))]
    [DependsOn(typeof(OrdersEntityFrameworkCoreModule))]
    [DependsOn(typeof(PaymentsEntityFrameworkCoreModule))]
    [DependsOn(typeof(PricingEntityFrameworkCoreModule))]
    [DependsOn(typeof(ProductComparisonEntityFrameworkCoreModule))]
    [DependsOn(typeof(ProductRecentlyViewedEntityFrameworkCoreModule))]
    [DependsOn(typeof(SearchEntityFrameworkCoreModule))]
    [DependsOn(typeof(ShipmentsEntityFrameworkCoreModule))]
    [DependsOn(typeof(ShippingEntityFrameworkCoreModule))]
    [DependsOn(typeof(ShoppingCartEntityFrameworkCoreModule))]
    [DependsOn(typeof(StorageEntityFrameworkCoreModule))]
    [DependsOn(typeof(TaxEntityFrameworkCoreModule))]
    [DependsOn(typeof(VendorsEntityFrameworkCoreModule))]
    public class HitCommerceEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HitCommerceEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HitCommerceDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also HitCommerceMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        }
    }
}
