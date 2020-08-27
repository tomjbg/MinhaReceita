using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Models;

namespace minhareceita.domain.Interfaces
{
    public interface IPerfilRep
    {
        Task<ICollection<Perfil>> ObterTodos();
        Task<Perfil> ObterPorId(Guid Id);
    }
}
