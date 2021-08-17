using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Cms
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CmsDomainSharedModule)
    )]
    public class CmsDomainModule : AbpModule
    {

    }
}
