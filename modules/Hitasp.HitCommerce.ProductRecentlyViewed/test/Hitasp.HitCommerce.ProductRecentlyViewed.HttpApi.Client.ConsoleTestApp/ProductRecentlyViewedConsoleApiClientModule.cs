using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductRecentlyViewed
{
    [DependsOn(
        typeof(ProductRecentlyViewedHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ProductRecentlyViewedConsoleApiClientModule : AbpModule
    {
        
    }
}
