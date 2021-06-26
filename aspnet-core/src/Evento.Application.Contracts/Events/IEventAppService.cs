using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evento.Events
{
    public interface IEventAppService:IApplicationService
    {
        Task<Guid> CreateAsync(EventCreationDto input);
        
        Task<PagedResultDto<EventDto>> GetUpcomingAsync();
        Task<EventDetailDto> GetAsync(Guid id);

        Task RegisterAsync(Guid id);

        Task UnregisterAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}