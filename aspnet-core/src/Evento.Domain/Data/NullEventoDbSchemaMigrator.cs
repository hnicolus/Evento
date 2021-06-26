using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Evento.Data
{
    /* This is used if database provider does't define
     * IEventoDbSchemaMigrator implementation.
     */
    public class NullEventoDbSchemaMigrator : IEventoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}