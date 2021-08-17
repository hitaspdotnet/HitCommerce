using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Payments
{
    [DependsOn(
        typeof(PaymentsHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PaymentsConsoleApiClientModule : AbpModule
    {
        
    }
}
