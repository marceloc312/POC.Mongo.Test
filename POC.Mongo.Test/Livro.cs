using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace POC.Mongo.Test
{
    public class Livro
    {
        public Livro()
        {
            Assunto = new List<string>();
        }

        public Livro(string id, string titulo, string autor, string ano, string páginas, List<string> assunto)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Páginas = páginas;
            Assunto = assunto;
        }

        [BsonRepresentation( MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Ano { get; set; }
        public string Páginas { get; set; }
        public List<string> Assunto { get; set; }
    }

}
