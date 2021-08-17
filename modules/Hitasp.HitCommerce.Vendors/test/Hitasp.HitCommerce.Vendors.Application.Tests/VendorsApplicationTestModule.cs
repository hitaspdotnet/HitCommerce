using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Vendors
{
    [DependsOn(
        typeof(VendorsApplicationModule),
        typeof(VendorsDomainTestModule)
        )]
    public class VendorsApplicationTestModule : AbpModule
    {

    }
}
