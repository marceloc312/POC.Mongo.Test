using MongoDB.Bson;
using MongoDB.Driver;
using System;
using Xunit;

namespace POC.Mongo.Test
{
    public class ConnectionMongoTest
    {
        readonly IMongoClient mongoClient;
        private const string TRAIT_CONNECT_MONGO = "Conection Mongo";

        public ConnectionMongoTest()
        {
            mongoClient = new MongoClient("mongodb://mongoadmin:secret@192.168.0.3:27017/?authSource=admin");
        }

        [Trait(TRAIT_CONNECT_MONGO, "Connect")]
        [Fact(DisplayName = "Deve inserir objeto JSON Bson com sucesso no mongo")]
        public async void DeveInerirObjetoBson()
        {
            var database = mongoClient.GetDatabase("test");
            var doc = new BsonDocument
            {
                {"Título", "Guerra dos Tronos"},
                {"Autor", "George R R Martin"},
                {"Ano", "1999"},
                {"Páginas", "856"}
            };

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);
            var livros = database.GetCollection<BsonDocument>("Livros");
            await livros.InsertOneAsync(doc);
        }

        [Trait(TRAIT_CONNECT_MONGO, "Connect")]
        [Fact(DisplayName = "Deve inserir Objeto Livro com sucesso no mongo")]
        public async void DeveInerirObjetoLivro()
        {
            var database = mongoClient.GetDatabase("test");
            var livro = new Livro
            {
                Titulo= "Engenharia de Software",
                Autor="Marcelo Miranda",
                Ano= "2021",
                Páginas= "1234"
            };

            livro.Assunto.Add("Fantasia");
             livro.Assunto.Add("Ação");

            var livros = database.GetCollection<Livro>("Livros");
            await livros.InsertOneAsync(livro);
        }
    }

}
