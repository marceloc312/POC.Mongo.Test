using MongoDB.Driver;
using POC.Mongo.Test.Repositorys;
using POC.Mongo.Test.Repositorys.Contracts;
using System.Collections.Generic;

namespace POC.Mongo.Test.Factories
{
    public sealed class Factory
    {
        static IDatabase _database;
        public static IDatabase GetDatabaseInstance()
        {
            if (_database == null)
            {
                _database = new Database(new DatabaseSettings("mongodb://mongoadmin:secret@192.168.0.3:27017/?authSource=admin", "test"));
            }

            return _database;
        }
    }
}
