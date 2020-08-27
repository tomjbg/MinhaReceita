using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Models;

namespace minhareceita.domain.Interfaces
{
    public interface IReceitaRep
    {
        Task<ICollection<Receita>> ObterTodos();
        Task<Receita> ObterPorId(Guid Id);
    }
}
