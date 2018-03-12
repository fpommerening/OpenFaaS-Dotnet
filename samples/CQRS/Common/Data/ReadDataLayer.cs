using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Data
{
    public class ReadDataLayer
    {
        private IMongoClient _mongoClient;


        private IMongoClient Client()
        {
            if (_mongoClient == null)
            {
                var cnn = DockerSecretHelper.GetSecretValue("ReadCnn");
                _mongoClient = new MongoClient(cnn);
            }
            return _mongoClient;
        }
    }
}
