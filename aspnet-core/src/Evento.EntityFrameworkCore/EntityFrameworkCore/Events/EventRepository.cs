using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.Events;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;

namespace Evento.EntityFrameworkCore.Events
{
    public class EventRepository : EfCoreRepository<EventoDbContext, Event, Guid>, IEventRepository
    {
        private readonly IDataFilter _dataFilter;
        private readonly IClock _clock;

        public EventRepository(IDataFilter dataFilter,IClock clock, IDbContextProvider<EventoDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
            _dataFilter = dataFilter;
            _clock = clock;
        }

        public async Task<Event> FindByIdAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return dbSet
                .IncludeDetails(true)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Event>> GetUpComingEventsAsync(bool includeDetails = false)
        {
            var queryable = await GetQueryableAsync();
            
            var query = queryable.Where(x => x.StartTime > _clock.Now);

            var result = await AsyncExecuter.ToListAsync(query);
            return result;
        }
    }
}