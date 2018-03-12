using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.ReadModels
{
    public class ConferenceListItem
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("conferenceid")]
        public Guid ConferenceId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("start")]
        public DateTime Start { get; set; }

        [BsonElement("end")]
        public DateTime End { get; set; }
    }
}
