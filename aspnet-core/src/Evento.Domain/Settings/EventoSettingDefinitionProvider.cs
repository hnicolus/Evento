using Volo.Abp.Settings;

namespace Evento.Settings
{
    public class EventoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(EventoSettings.MySetting1));
        }
    }
}
