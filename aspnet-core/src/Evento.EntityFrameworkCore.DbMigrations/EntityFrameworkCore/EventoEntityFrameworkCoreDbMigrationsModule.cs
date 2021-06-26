using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Evento.EntityFrameworkCore
{
    [DependsOn(
        typeof(EventoEntityFrameworkCoreModule)
        )]
    public class EventoEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EventoMigrationsDbContext>();
        }
    }
}
