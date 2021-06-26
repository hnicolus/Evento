using System.Threading.Tasks;

namespace Evento.Data
{
    public interface IEventoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
