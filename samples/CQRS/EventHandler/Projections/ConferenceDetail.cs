using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.ReadModels;
using Domain.Events;

namespace EventHandler.Projections
{
    public class ConferenceDetail
    {
        public static Task Handle(AddConferenceEvent addConferenceEvent)
        {
            var dl = new HandlerDataLayer();
            var item = new ConferenceItem
            {
                ConferenceId = addConferenceEvent.Id,
                Name = addConferenceEvent.Name,
                Start = addConferenceEvent.Start,
                End = addConferenceEvent.End,
                Description = addConferenceEvent.Description,
                RegistrationStart = addConferenceEvent.RegistrationStart,
                RegistrationEnd = addConferenceEvent.RegistrationEnd,
                Attendees = new List<Attendee>()
            };
            return dl.SaveConferenceItem(item);
        }

        public static async Task Handle(NewRegistrationEvent newRegistrationEvent)
        {
            var dl = new HandlerDataLayer();
            var conference = await dl.GetConferenceItemById(newRegistrationEvent.ConferenceId);
            conference.Attendees.Add(new Attendee
            {
                Name = newRegistrationEvent.Name,
                FirstName = newRegistrationEvent.FirstName,
                Email = newRegistrationEvent.Email,
                Company = newRegistrationEvent.Company,
                RegistrationId = newRegistrationEvent.Id
            });
            await dl.SaveConferenceItem(conference);
        }

        public static async Task Handle(CancelRegistrationEvent cancelRegistrationEvent)
        {
            var dl = new HandlerDataLayer();
            var conference = await dl.GetConferenceItemById(cancelRegistrationEvent.ConferenceId);
            var attendee = conference.Attendees.FirstOrDefault(x => x.RegistrationId == cancelRegistrationEvent.RegistrationId);

            if (attendee != null)
            {
                conference.Attendees.Remove(attendee);
            }
            await dl.SaveConferenceItem(conference);
        }
    }
}
