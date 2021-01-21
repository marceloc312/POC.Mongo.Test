using MongoDB.Driver;
using POC.Mongo.Test.Repositorys.Contracts;

namespace POC.Mongo.Test.Repositorys
{
    public class Database : IDatabase
    {
        readonly IMongoDatabase mongoDatabase;

        public Database(DatabaseSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return mongoDatabase.GetCollection<T>(name);
        }
    }
}
