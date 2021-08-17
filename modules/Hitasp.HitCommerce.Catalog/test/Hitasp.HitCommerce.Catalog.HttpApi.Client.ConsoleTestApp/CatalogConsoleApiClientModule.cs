using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CatalogConsoleApiClientModule : AbpModule
    {
        
    }
}
