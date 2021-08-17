using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Cms
{
    [DependsOn(
        typeof(CmsApplicationModule),
        typeof(CmsDomainTestModule)
        )]
    public class CmsApplicationTestModule : AbpModule
    {

    }
}
