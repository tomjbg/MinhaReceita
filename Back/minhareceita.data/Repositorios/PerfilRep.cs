using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Interfaces;
using minhareceita.domain.Models;

namespace minhareceita.data.Repositorios
{
    public class PerfilRep : IPerfilRep
    {
        private readonly IRepository<Perfil> _repository;

        public PerfilRep(IRepository<Perfil> repository)
        {
            this._repository = repository;
        }
        public async Task<Perfil> ObterPorId(Guid Id)
        {
            return await _repository.ObterPorId(Id);
        }

        public async Task<ICollection<Perfil>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
    }
}
