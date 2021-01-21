using MongoDB.Driver;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys.Contracts;

namespace POC.Mongo.Test.Repositorys.Criterias
{
    internal class LivroAssuntoCriteria : ICriteria
    {
        string[] assuntos;
        public LivroAssuntoCriteria(string[] assunto)
        {
            this.assuntos = assunto;
            CreateFilterDefinition();
        }

        public object Filter { get; private set; }

        void CreateFilterDefinition()
        {
            var builder = Builders<Livro>.Filter;

            Filter = builder.AnyIn(x => x.Assunto, assuntos);
        }
    }
}
