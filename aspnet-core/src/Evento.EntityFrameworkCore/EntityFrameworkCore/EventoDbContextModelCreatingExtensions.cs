using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Evento.EntityFrameworkCore
{
    public static class EventoDbContextModelCreatingExtensions
    {
        public static void ConfigureEvento(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}