using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Hitasp.HitCommerce.Web
{
    [Dependency(ReplaceServices = true)]
    public class HitCommerceBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "HitCommerce";
    }
}
