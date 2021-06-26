using AutoMapper;
using Evento.Events;

namespace Evento
{
    public class EventoApplicationAutoMapperProfile : Profile
    {
        public EventoApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<EventCreationDto, Event>();
            CreateMap<Event, EventDto>();
            CreateMap<Event, EventDetailDto>();
            CreateMap<EventAttendee, EventAttendeeDto>();
        }
    }
}
