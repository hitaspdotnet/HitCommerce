using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Hitasp.HitCommerce.PublicWeb
{
    [Dependency(ReplaceServices = true)]
    public class HitCommercePublicBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "HitCommerce";
    }
}