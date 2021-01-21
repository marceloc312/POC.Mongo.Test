using MongoDB.Bson;
using MongoDB.Driver;
using POC.Mongo.Test.Factories;
using POC.Mongo.Test.Models;
using POC.Mongo.Test.Repositorys;
using POC.Mongo.Test.Repositorys.Contracts;
using POC.Mongo.Test.Repositorys.Criterias;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace POC.Mongo.Test.Tests
{
    public class ListarTest
    {
        private readonly ITestOutputHelper _output;
        readonly ILivroCriteriaBuilder _livroCriteriaBuilder;
        readonly ILivroRepository _livroRepository;
        private const string TRAIT_CONNECT_MONGO = "Listar";
        private const int TotalLivrosExpected = 13;

        public ListarTest(ITestOutputHelper output)
        {
            _output = output;
            _livroRepository = new LivroRepository(Factory.GetInstanceMongoClient(), "test");
            _livroCriteriaBuilder = new LivroCriteriaBuilder();
        }

        [Trait(TRAIT_CONNECT_MONGO, "Todos")]
        [Fact(DisplayName = "Deve listar todos os livros com sucesso no mongo")]
        public async void DeveListarTodos()
        {
            // Arrange
            ICriteria filtro = _livroCriteriaBuilder.Empty();
            // Act
            var livros = await _livroRepository.Find(filtro);

            // Assert
            _output.WriteLine($"Total livros: { livros.Count()}");
            Assert.Equal(TotalLivrosExpected, livros.Count());
        }

        [Trait(TRAIT_CONNECT_MONGO, "Com Filtro")]
        [Fact(DisplayName = "Deve encontrar pelo titulo")]
        public async void DeveListarPeloTitulo()
        {
            // Arrange
            ICriteria filtro = _livroCriteriaBuilder.PorTitulo("A Dança com os Dragões");
            // Act
            var livros = await _livroRepository.Find(filtro);

            // Assert
            _output.WriteLine($"Total livros: { livros.Count()}");
            Assert.Single(livros);
        }

        [Trait(TRAIT_CONNECT_MONGO, "Com Filtro")]
        [Fact(DisplayName = "Deve encontrar por assunto")]
        public async void DeveListarPeloAssunto()
        {
            // Arrange
            ICriteria filtro = _livroCriteriaBuilder.PorAssuntos(new[] { "Ação", "Infantil" });
            // Act
            var livros = await _livroRepository.Find(filtro);

            // Assert
            _output.WriteLine($"Total livros: { livros.Count()}");
            Assert.Equal(11, livros.Count());
        }

        [Trait(TRAIT_CONNECT_MONGO, "Com Filtro")]
        [Fact(DisplayName = "Deve filtrar entre datas de lançamento")]
        public async void DeveFiltrarEntreDatasDeLancamento()
        {
            // Arrange
            ICriteria filtro = _livroCriteriaBuilder.PorAnoLancamentoDeAte(2006, 2008);
            // Act
            var livros = await _livroRepository.Find(filtro);

            // Assert
            _output.WriteLine($"Total livros: { livros.Count()}");
            Assert.Equal(3, livros.Count());
        }
    }
}
