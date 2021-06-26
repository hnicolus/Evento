using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Evento.Events
{
    public interface IEventRepository :IRepository<Event,Guid>
    {
        Task<Event> FindByIdAsync(Guid id);
        Task<List<Event>> GetUpComingEventsAsync(bool includeDetails = false);
    }
}