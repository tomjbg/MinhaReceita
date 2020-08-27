using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Models;

namespace minhareceita.domain.Interfaces
{
    public interface IPerfilService
    {
        Task<Perfil> Adicionar(Perfil perfil);
        Task<Perfil> Atualizar(Perfil perfil);
        Task<Perfil> Deletar(Guid Id);
    }
}
