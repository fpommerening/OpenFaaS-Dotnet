using System;
using System.Threading.Tasks;
using Data.ReadModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Data
{
    public class HandlerDataLayer
    {
        private IMongoClient _mongoClient;

        public async Task<AttendeeListItem> GetAttendeeListItemByEmail(string email)
        {
            var collection = Database().GetCollection<AttendeeListItem>("AttendeeList");
            var builder = Builders<AttendeeListItem>.Filter;
            var filter = builder.Eq(x => x.Email, email);

            using (var filterResult = await collection.FindAsync(filter))
            {
                return await filterResult.FirstOrDefaultAsync();
            }
        }

        public Task SaveAttendeeListItem(AttendeeListItem attendee)
        {
            var collection = Database().GetCollection<AttendeeListItem>("AttendeeList");
            if (attendee.Id == ObjectId.Empty)
            {
               return collection.InsertOneAsync(attendee);
            }
            else
            {
                var filter = Builders<AttendeeListItem>.Filter.Eq(s => s.Id, attendee.Id);
                return collection.ReplaceOneAsync(filter, attendee);
            }
        }

        public Task SaveConferenceItem(ConferenceItem conference)
        {
            var collection = Database().GetCollection<ConferenceItem>("Conference");
            if (conference.Id == ObjectId.Empty)
            {
                return collection.InsertOneAsync(conference);
            }
            else
            {
                var filter = Builders<ConferenceItem>.Filter.Eq(s => s.Id, conference.Id);
                return collection.ReplaceOneAsync(filter, conference);
            }
        }

        public async Task<ConferenceItem> GetConferenceItemById(Guid id)
        {
            var collection = Database().GetCollection<ConferenceItem>("Conference");
            var builder = Builders<ConferenceItem>.Filter;
            var filter = builder.Eq(x => x.ConferenceId, id);

            using (var filterResult = await collection.FindAsync(filter))
            {
                return await filterResult.FirstOrDefaultAsync();
            }
        }

        public Task SaveConferenceListItem(ConferenceListItem conference)
        {
            var collection = Database().GetCollection<ConferenceListItem>("ConferenceList");
            return collection.InsertOneAsync(conference);
        }

        private IMongoDatabase Database()
        {
            if (_mongoClient == null)
            {
                var cnn = DockerSecretHelper.GetSecretValue("HandlerCnn");
                _mongoClient = new MongoClient(cnn);
            }
            return _mongoClient.GetDatabase("ReadModel");
        }
    }
}
