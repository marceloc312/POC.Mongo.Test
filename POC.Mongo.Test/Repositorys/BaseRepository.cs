using MongoDB.Driver;
using POC.Mongo.Test.Repositorys.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Mongo.Test.Repositorys
{
    public abstract class BaseRepository<T> where T : class
    {
       protected readonly IMongoCollection<T> _collection;
        public BaseRepository(IDatabase database,string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public virtual async Task InsertAsync(T model)
        {
            await _collection.InsertOneAsync(model);
        }

        public async Task<IEnumerable<T>> FindAsync(ICriteria criteria)
        {
            var filtro = (FilterDefinition<T>)criteria.Filter;
            var query = await _collection.FindAsync<T>(filtro);

            return await query.ToListAsync();
        }
    }
}
