using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Tax
{
    [DependsOn(
        typeof(TaxHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class TaxConsoleApiClientModule : AbpModule
    {
        
    }
}
