using System;

namespace Evento.Events
{
    public  class EventAttendeeDto
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreationTime { get; set; }
    }
}