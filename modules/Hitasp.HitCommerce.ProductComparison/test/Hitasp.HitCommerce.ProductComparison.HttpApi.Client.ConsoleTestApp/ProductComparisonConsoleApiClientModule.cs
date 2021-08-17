using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductComparison
{
    [DependsOn(
        typeof(ProductComparisonHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ProductComparisonConsoleApiClientModule : AbpModule
    {
        
    }
}
