using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.ReadModels
{
    public class AttendeeListItem
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("company")]
        public string Company { get; set; }

        [BsonElement("count")]
        public int Count { get; set; }
    }
}
