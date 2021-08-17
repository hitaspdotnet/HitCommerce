using Volo.Abp.Settings;

namespace Hitasp.HitCommerce.Settings
{
    public class HitCommerceSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HitCommerceSettings.MySetting1));
        }
    }
}
