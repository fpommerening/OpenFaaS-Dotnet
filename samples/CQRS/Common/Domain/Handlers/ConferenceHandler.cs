using System;
using System.Collections.Generic;
using System.Text;
using Domain.Commands;
using Domain.Events;

namespace Domain.Handlers
{
    public class ConferenceHandler
    {
        public IEnumerable<EventBase> Handle(AddConference command)
        {
            yield return new AddConferenceEvent();
        }
    }
}
