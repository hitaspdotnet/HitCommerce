using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Tax
{
    [DependsOn(
        typeof(TaxApplicationModule),
        typeof(TaxDomainTestModule)
        )]
    public class TaxApplicationTestModule : AbpModule
    {

    }
}
