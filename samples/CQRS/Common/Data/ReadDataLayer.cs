using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.ReadModels;
using MongoDB.Driver;

namespace Data
{
    public class ReadDataLayer
    {
        private IMongoClient _mongoClient;

        public List<ConferenceListItem> GetConferenceList()
        {
            var collection = Database().GetCollection<ConferenceListItem>("ConferenceList");
            var filter = Builders<ConferenceListItem>.Filter.Empty;

            var resultList = new List<ConferenceListItem>();

            using (var filterResult = collection.FindSync(filter))
            {
                while (filterResult.MoveNext())
                {
                    resultList.AddRange(filterResult.Current);
                }
            }

            return resultList;
        }

        public ConferenceItem GetConferenceDetail(Guid conferenceId)
        {
            var collection = Database().GetCollection<ConferenceItem>("Conference");
            var builder = Builders<ConferenceItem>.Filter;
            var filter = builder.Eq(x => x.ConferenceId, conferenceId);

            using (var filterResult = collection.FindSync(filter))
            {
                return filterResult.FirstOrDefault();
            }
        }

        public List<AttendeeListItem> GetAttendeeList()
        {
            var collection = Database().GetCollection<AttendeeListItem>("AttendeeList");
            var filter = Builders<AttendeeListItem>.Filter.Empty;

            var resultList = new List<AttendeeListItem>();

            using (var filterResult = collection.FindSync(filter))
            {
                while (filterResult.MoveNext())
                {
                    resultList.AddRange(filterResult.Current);
                }
            }

            return resultList;
        }

      


        private IMongoDatabase Database()
        {
            if (_mongoClient == null)
            {
                var cnn = DockerSecretHelper.GetSecretValue("ReadCnn");
                _mongoClient = new MongoClient(cnn);
            }
            return _mongoClient.GetDatabase("ReadModel"); ;
        }
    }
}
