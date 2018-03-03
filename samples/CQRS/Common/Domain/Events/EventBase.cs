using System;

namespace Domain.Events
{
    public abstract class EventBase
    {
        public Guid Id { get; set; }
    }
}
