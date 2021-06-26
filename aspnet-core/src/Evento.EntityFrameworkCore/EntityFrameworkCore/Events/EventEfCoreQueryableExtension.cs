using System.Linq;
using Evento.Events;
using Microsoft.EntityFrameworkCore;

namespace Evento.EntityFrameworkCore.Events
{
    public static class EventEfCoreQueryableExtension
    {
        public static IQueryable<Event> IncludeDetails(this IQueryable<Event> queryable, bool include = false)
        {
            if (!include) return queryable;

            return queryable.Include(@event => @event.Attendees);
        }
    }
}