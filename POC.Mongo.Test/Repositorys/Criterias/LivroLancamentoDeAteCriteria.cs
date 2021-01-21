using MongoDB.Driver;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys.Contracts;

namespace POC.Mongo.Test.Repositorys.Criterias
{
    internal class LivroLancamentoDeAteCriteria : ICriteria
    {
        int de;
        int ate;

        public LivroLancamentoDeAteCriteria(int de, int ate)
        {
            this.de = de;
            this.ate = ate;
            CreateFilterDefinition();
        }

        public object Filter { get; private set; }

        void CreateFilterDefinition()
        {
            var builder = Builders<Livro>.Filter;

            Filter = builder.And(builder.Gte(x => x.Ano, de), builder.Lte(x => x.Ano, ate));
        }
    }
}
