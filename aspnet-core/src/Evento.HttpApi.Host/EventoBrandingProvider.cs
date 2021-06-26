using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Evento
{
    [Dependency(ReplaceServices = true)]
    public class EventoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Evento";
    }
}
