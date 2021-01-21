using MongoDB.Driver;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC.Mongo.Test.Repositorys
{

    public class LivroRepository : ILivroRepository
    {
        readonly IMongoCollection<Livro> _collection;

        public LivroRepository(IMongoClient mongoClient, string dbname)
        {
            var database = mongoClient.GetDatabase(dbname);
            _collection = database.GetCollection<Livro>("Livros");
        }

        public async Task<IEnumerable<Livro>> Find(ICriteria criteria)
        {
            var filtro = (FilterDefinition<Livro>)criteria.Filter;
            var query = await _collection.FindAsync<Livro>(filtro);

            return await query.ToListAsync();
        }

        public async Task Insert(Livro model)
        {
            await _collection.InsertOneAsync(model);
        }
    }
}
