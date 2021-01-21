using MongoDB.Driver;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys.Contracts;

namespace POC.Mongo.Test.Repositorys.Criterias
{
    internal class LivroEmptyCriteria : ICriteria
    {

        public LivroEmptyCriteria()
        {
            CreateFilterDefinition();
        }

        public object Filter { get; private set; }

        void CreateFilterDefinition()
        {
            var builder = Builders<Livro>.Filter;
            Filter = builder.Empty;
        }
    }
}
