using System;
using System.Linq;
using System.Threading.Tasks;
using Evento.Events;
using Microsoft.AspNetCore.Components;

namespace Evento.Blazor.Pages
{
    public partial class EventDetail
    {
        [Parameter] public string Id { get; set; }

        private EventDetailDto Event { get; set; }
        private bool IsRegistered { get; set; }

        [Inject] public IEventAppService EventAppService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetEventAsync();
        }

        private async Task GetEventAsync()
        {
            Event = await EventAppService.GetAsync(Guid.Parse(Id));
            if (CurrentUser.IsAuthenticated)
            {
                IsRegistered = Event.Attendees.Any(a => a.UserId == CurrentUser.Id);
            }
        }

        private async Task Register()
        {
            await EventAppService.RegisterAsync(Guid.Parse(Id));
            await GetEventAsync();
        }

        private async Task UnRegister()
        {
            await EventAppService.UnregisterAsync(Guid.Parse(Id));
            await GetEventAsync();
        }

        private async Task Delete()
        {
            if (!await Message.Confirm("This event will be deleted: " + Event.Title))
            {
                return;
            }

            await EventAppService.DeleteAsync(Guid.Parse(Id));
            NavigationManager.NavigateTo("/");
        }
    }
}