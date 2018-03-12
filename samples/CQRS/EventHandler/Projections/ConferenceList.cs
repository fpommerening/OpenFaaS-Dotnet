using System.Threading.Tasks;
using Data;
using Data.ReadModels;
using Domain.Events;

namespace EventHandler.Projections
{
    public class ConferenceList
    {
        public static Task Handle(AddConferenceEvent addConferenceEvent)
        {
            var dl = new HandlerDataLayer();
            var item = new ConferenceListItem
            {
                ConferenceId = addConferenceEvent.Id,
                Name = addConferenceEvent.Name,
                Start = addConferenceEvent.Start,
                End = addConferenceEvent.End
            };
            return dl.SaveConferenceListItem(item);
        }
    }
}
