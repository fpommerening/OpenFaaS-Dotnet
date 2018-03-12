using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.ReadModels
{
    public class Attendee
    {
        [BsonElement("registrationId")]
        public Guid RegistrationId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("company")]
        public string Company { get; set; }
    }
}
