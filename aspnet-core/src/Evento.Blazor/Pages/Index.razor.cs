using System.Collections.Generic;
using System.Threading.Tasks;
using Evento.Events;
using Microsoft.AspNetCore.Components;

namespace Evento.Blazor.Pages
{
    public partial class Index
    {
        private IReadOnlyList<EventDto> UpcomingEvents { get; set; } = new List<EventDto>();
        [Inject] private IEventAppService EventAppService { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            UpcomingEvents = (await EventAppService.GetUpcomingAsync()).Items;
        }
    }
}
