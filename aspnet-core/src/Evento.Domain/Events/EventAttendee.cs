using System;
using Volo.Abp.Auditing;

namespace Evento.Events
{
    public class EventAttendee : IHasCreationTime
    {
        public int Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}