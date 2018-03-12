using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.ReadModels
{
    public class ConferenceItem
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("conferenceid")]
        public Guid ConferenceId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("start")]
        public DateTime Start { get; set; }

        [BsonElement("end")]
        public DateTime End { get; set; }

        [BsonElement("registrationstart")]
        public DateTime? RegistrationStart { get; set; }

        [BsonElement("registrationend")]
        public DateTime? RegistrationEnd { get; set; }

        public List<Attendee> Attendees { get; set; }
    }
}
