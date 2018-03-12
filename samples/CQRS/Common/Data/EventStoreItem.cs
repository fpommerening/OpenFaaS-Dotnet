using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data
{
    public class EventStoreItem
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("event")]
        public object Event { get; set; }

        [BsonElement("eventtype")]
        public string EventType { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
