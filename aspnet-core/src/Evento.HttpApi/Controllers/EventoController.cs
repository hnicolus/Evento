using Evento.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Evento.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class EventoController : AbpController
    {
        protected EventoController()
        {
            LocalizationResource = typeof(EventoResource);
        }
    }
}