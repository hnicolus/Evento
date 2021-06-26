using System;
using System.Collections.Generic;
using System.Text;
using Evento.Localization;
using Volo.Abp.Application.Services;

namespace Evento
{
    /* Inherit your application services from this class.
     */
    public abstract class EventoAppService : ApplicationService
    {
        protected EventoAppService()
        {
            LocalizationResource = typeof(EventoResource);
        }
    }
}
