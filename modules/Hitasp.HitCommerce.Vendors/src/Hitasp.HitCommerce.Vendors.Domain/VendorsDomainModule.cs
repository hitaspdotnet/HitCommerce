using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Vendors
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(VendorsDomainSharedModule)
    )]
    public class VendorsDomainModule : AbpModule
    {

    }
}
