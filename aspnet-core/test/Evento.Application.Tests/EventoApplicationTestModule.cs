using Volo.Abp.Modularity;

namespace Evento
{
    [DependsOn(
        typeof(EventoApplicationModule),
        typeof(EventoDomainTestModule)
        )]
    public class EventoApplicationTestModule : AbpModule
    {

    }
}