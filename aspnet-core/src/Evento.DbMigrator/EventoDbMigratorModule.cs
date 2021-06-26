using Evento.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Evento.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EventoEntityFrameworkCoreDbMigrationsModule),
        typeof(EventoApplicationContractsModule)
        )]
    public class EventoDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
