using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public abstract class EventBase
    {
        public Guid Id { get; set; }
    }
}
