using MongoDB.Driver;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys.Contracts;
using System;
using System.Text;

namespace POC.Mongo.Test.Repositorys
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(IDatabase database) : base(database, "Livros")
        {
        }
    }
}
