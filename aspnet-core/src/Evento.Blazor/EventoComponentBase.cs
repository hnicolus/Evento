using Evento.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Evento.Blazor
{
    public abstract class EventoComponentBase : AbpComponentBase
    {
        protected EventoComponentBase()
        {
            LocalizationResource = typeof(EventoResource);
        }
    }
}
