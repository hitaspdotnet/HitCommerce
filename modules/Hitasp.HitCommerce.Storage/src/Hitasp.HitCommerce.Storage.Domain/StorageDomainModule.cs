using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Storage
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(StorageDomainSharedModule)
    )]
    public class StorageDomainModule : AbpModule
    {

    }
}
