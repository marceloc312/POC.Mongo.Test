using MongoDB.Driver;
using System.Collections.Generic;

namespace POC.Mongo.Test.Factories
{
    public static class Factory
    {
        static IMongoClient _instanceMongo;
        public static IMongoClient GetInstanceMongoClient()
        {
            return _instanceMongo = _instanceMongo ?? new MongoClient("mongodb://mongoadmin:secret@192.168.0.3:27017/?authSource=admin");
        }
    }
}
