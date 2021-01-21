using POC.Mongo.Test.Repositorys.Contracts;

namespace POC.Mongo.Test.Repositorys.Criterias
{
    internal class LivroCriteriaBuilder : ILivroCriteriaBuilder
    {
        public ICriteria Empty()
        {
            return new LivroEmptyCriteria();
        }

        public ICriteria PorAnoLancamentoDeAte(int anoDe, int anoAte)
        {
            return new LivroLancamentoDeAteCriteria(anoDe, anoAte);
        }

        public ICriteria PorAssuntos(string[] assuntos)
        {
            return new LivroAssuntoCriteria(assuntos);
        }

        public ICriteria PorTitulo(string titulo)
        {
            return new LivroTituloCriteria(titulo);
        }
    }
}
