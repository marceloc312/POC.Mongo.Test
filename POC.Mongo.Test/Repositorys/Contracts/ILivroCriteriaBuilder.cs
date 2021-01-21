namespace POC.Mongo.Test.Repositorys.Contracts
{
    public interface ILivroCriteriaBuilder
    {
        ICriteria PorTitulo(string titulo);
        ICriteria PorAssuntos(string[] assuntos);
        ICriteria PorAnoLancamentoDeAte(int anoDe, int anoAte);
        ICriteria Empty();
    }
}
