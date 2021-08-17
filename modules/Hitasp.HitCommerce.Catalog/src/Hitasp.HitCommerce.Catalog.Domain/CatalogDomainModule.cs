using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CatalogDomainSharedModule)
    )]
    public class CatalogDomainModule : AbpModule
    {

    }
}
