using POC.Mongo.Test.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Mongo.Test.Repositorys.Contracts
{
    public interface ILivroRepository
    {
        Task InsertAsync(Livro model);
        Task<IEnumerable<Livro>> FindAsync(ICriteria criteria);
    }
}
