using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Evento.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class EventoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Evento";
    }
}
