using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Core
{
    [DependsOn(
        typeof(CoreApplicationModule),
        typeof(CoreDomainTestModule)
        )]
    public class CoreApplicationTestModule : AbpModule
    {

    }
}
