using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Hitasp.HitCommerce.Vendors
{
    [DependsOn(
        typeof(VendorsDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class VendorsApplicationContractsModule : AbpModule
    {

    }
}
