using AutoFixture;
using MongoDB.Bson;
using MongoDB.Driver;
using POC.Mongo.Test.Factories;
using POC.Mongo.Test.Repositorys;
using POC.Mongo.Test.Repositorys.Contracts;
using System;
using Xunit;

namespace POC.Mongo.Test.Tests
{
    public partial class IncluirBsonDocumentTest
    {
        private const string TRAIT_CONNECT_MONGO = "Incluir Mongo";
        Fixture fixture = new Fixture();
        readonly IMongoClient mongoClient;

        public IncluirBsonDocumentTest()
        {
            mongoClient = new MongoClient("mongodb://mongoadmin:secret@192.168.0.3:27017/?authSource=admin");            
        }

        [Trait("Category", "SkipWhenLiveUnitTesting")]
        [Trait(TRAIT_CONNECT_MONGO, "BsonDocument")]
        [Fact(DisplayName = "Deve inserir objeto BsonDocument com sucesso no mongo")]
        public async void DeveInerirObjetoBson()
        {
            var ticketDeControle = DateTime.Now.Ticks;
            var random = new Random();
            var doc = new BsonDocument
            {
                {"Titulo", $"Guerra dos Tronos {ticketDeControle}" },
                {"Autor", $"George R R Martin { ticketDeControle}"},
                {"Ano", random.Next( 1999,2020)},
                {"Paginas", random.Next( 100,1200)}
            };

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);
            var livros = mongoClient.GetDatabase("test").GetCollection<BsonDocument>("Livros");
            await livros.InsertOneAsync(doc);
        }

    }
}
