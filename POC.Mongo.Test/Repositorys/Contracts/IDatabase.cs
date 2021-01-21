using MongoDB.Driver;

namespace POC.Mongo.Test.Repositorys.Contracts
{
    public interface IDatabase
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
