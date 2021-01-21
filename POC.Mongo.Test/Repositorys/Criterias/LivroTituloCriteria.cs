using MongoDB.Driver;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys.Contracts;

namespace POC.Mongo.Test.Repositorys.Criterias
{
    internal class LivroTituloCriteria : ICriteria
    {
        string titulo;

        public LivroTituloCriteria(string titulo)
        {
            this.titulo = titulo;
            CreateFilterDefinition();
        }

        public object Filter { get; private set; }

        void CreateFilterDefinition()
        {
            var builder = Builders<Livro>.Filter;

            Filter = builder.Eq(x => x.Titulo, titulo);
        }
    }
}
