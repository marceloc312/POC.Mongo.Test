using POC.Mongo.Test.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Mongo.Test.Repositorys.Contracts
{
    public interface ILivroRepository
    {
        Task Insert(Livro model);
        Task<IEnumerable<Livro>> Find(ICriteria criteria);
    }
}
