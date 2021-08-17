using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Pricing
{
    [DependsOn(
        typeof(PricingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PricingConsoleApiClientModule : AbpModule
    {
        
    }
}
