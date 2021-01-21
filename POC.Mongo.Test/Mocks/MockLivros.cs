using POC.Mongo.Test.Models;
using System.Collections.Generic;

namespace POC.Mongo.Test.Mocks
{
    public class MockLivros
    {
        public static IEnumerable<Livro> GenerateListLivros()
        {
            List<Livro> livros = new List<Livro>();
            livros.Add(incluiValoresLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"));
            livros.Add(incluiValoresLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"));
            livros.Add(incluiValoresLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"));
            livros.Add(incluiValoresLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"));
            livros.Add(incluiValoresLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"));
            livros.Add(incluiValoresLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"));
            livros.Add(incluiValoresLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"));
            livros.Add(incluiValoresLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"));
            livros.Add(incluiValoresLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"));
            livros.Add(incluiValoresLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"));
            livros.Add(incluiValoresLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"));
            livros.Add(incluiValoresLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"));
            livros.Add(incluiValoresLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação"));

            return livros;
        }
        static Livro incluiValoresLivro(string Titulo, string Autor, int Ano, int Paginas, string assuntos)
        {
            Livro livro = new Livro();
            livro.Titulo = Titulo;
            livro.Autor = Autor;
            livro.Ano = Ano;
            livro.Paginas = Paginas;

            string[] vetAssunto = assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();
            for (int i = 0; i <= vetAssunto.Length - 1; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }
            livro.Assunto = vetAssunto2;
            return livro;
        }
    }
}
