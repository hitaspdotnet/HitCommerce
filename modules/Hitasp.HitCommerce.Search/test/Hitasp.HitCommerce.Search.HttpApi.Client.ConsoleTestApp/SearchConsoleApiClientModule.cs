using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Search
{
    [DependsOn(
        typeof(SearchHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SearchConsoleApiClientModule : AbpModule
    {
        
    }
}
