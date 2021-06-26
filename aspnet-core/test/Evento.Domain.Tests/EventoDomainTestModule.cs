using Evento.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Evento
{
    [DependsOn(
        typeof(EventoEntityFrameworkCoreTestModule)
        )]
    public class EventoDomainTestModule : AbpModule
    {

    }
}