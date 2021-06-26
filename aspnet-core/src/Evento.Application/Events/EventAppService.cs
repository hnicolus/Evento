using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.Users;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Evento.Events
{
    public class EventAppService : EventoAppService, IEventAppService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public EventAppService(
            IEventRepository eventRepository,
            IRepository<AppUser, Guid> userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        public async Task<Guid> CreateAsync(EventCreationDto input)
        {
            var eventEntity = ObjectMapper.Map<EventCreationDto, Event>(input);
            await _eventRepository.InsertAsync(eventEntity);
            return eventEntity.Id;
        }

        public async Task<PagedResultDto<EventDto>> GetUpcomingAsync()
        {
            var queryable = _eventRepository.Where(x => x.StartTime > Clock.Now);
            var events = await AsyncExecuter.ToListAsync(queryable);
            var eventDtoList = ObjectMapper.Map<List<Event>, List<EventDto>>(events);
            return new PagedResultDto<EventDto>()
            {
                Items = eventDtoList
            };
        }

        public async Task<EventDetailDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.FindByIdAsync(id);
            var queryable = await _userRepository.GetQueryableAsync();

            var result = ObjectMapper.Map<Event, EventDetailDto>(@event);
            var users = await _userRepository.GetListAsync();

            foreach (var attendeeDto in result.Attendees)
            {
                attendeeDto.UserName = users.First(x => x.Id == attendeeDto.UserId).UserName;
            }

            return result;
        }

        [Authorize]
        public async Task RegisterAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            if (@event.Attendees.Any(a => a.UserId == CurrentUser.Id))
            {
                return;
            }

            @event.Attendees.Add(new EventAttendee
            {
                EventId = @event.Id,
                UserId = CurrentUser.GetId(),
                CreationTime = Clock.Now
            });
            await _eventRepository.UpdateAsync(@event);
        }

        [Authorize]
        public async Task UnregisterAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            var removedItems = @event.Attendees.RemoveAll(x => x.UserId == CurrentUser.Id);
            if (removedItems.Any())
            {
                await _eventRepository.UpdateAsync(@event);
            }
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);

            if (CurrentUser.Id != @event.CreatorId)
            {
                throw new UserFriendlyException("You don't have the necessary permission to delete this event!");
            }

            await _eventRepository.DeleteAsync(id);
        }
    }
}