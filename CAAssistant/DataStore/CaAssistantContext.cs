using CAAssistant.Models;
using MongoDB.Driver;

namespace CAAssistant.DataStore
{


    public class CaAssistantContext
    {
        private static IMongoDatabase _mongoDatabase;

        public CaAssistantContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("psmandco");
        }

        //public static IMongoDatabase MongoDatabase
        //{
        //    get { return _mongoDatabase; }
        //    set { _mongoDatabase = value; }
        //}

        public IMongoCollection<ClientFile> ClientFiles
        {
            get { return _mongoDatabase.GetCollection<ClientFile>("clients"); }
        }

    }

}