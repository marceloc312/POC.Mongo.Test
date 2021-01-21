using AutoFixture;
using MongoDB.Bson;
using MongoDB.Driver;
using POC.Mongo.Test.Factories;
using POC.Mongo.Test.Mocks;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys;
using POC.Mongo.Test.Repositorys.Contracts;
using System;
using Xunit;

namespace POC.Mongo.Test.Tests
{
    public partial class IncluirTest
    {
        private const string TRAIT_CONNECT_MONGO = "Incluir Mongo";

        readonly ILivroRepository _livroRepository;

        public IncluirTest()
        {
            var mongoClient = Factory.GetInstanceMongoClient();
            _livroRepository = new LivroRepository(mongoClient, "test");
        }

        [Trait("Category", "SkipWhenLiveUnitTesting")]
        [Trait(TRAIT_CONNECT_MONGO, "Objeto Livro")]
        [Fact(DisplayName = "Deve inserir Objeto Livro com sucesso no mongo")]
        public async void DeveInerirObjetoLivro()
        {
            var livros = MockLivros.GenerateListLivros();
            foreach (var livro in livros)
                await _livroRepository.Insert(livro);
        }
    }
}
