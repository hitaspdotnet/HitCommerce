using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Storage
{
    [DependsOn(
        typeof(StorageApplicationModule),
        typeof(StorageDomainTestModule)
        )]
    public class StorageApplicationTestModule : AbpModule
    {

    }
}
