using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Tax
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(TaxDomainSharedModule)
    )]
    public class TaxDomainModule : AbpModule
    {

    }
}
