using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace POC.Mongo.Test.Models
{
    public class Livro
    {
        public Livro()
        {
            Assunto = new List<string>();
        }

        public Livro(string id, string titulo, string autor, int ano, int paginas, List<string> assunto)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Paginas = paginas;
            Assunto = assunto;
        }

        [BsonRepresentation( MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }
    }

}
