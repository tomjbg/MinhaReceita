using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Interfaces;
using minhareceita.domain.Models;

namespace minhareceita.data.Repositorios
{
    public class ReceitaRep : IReceitaRep
    {
        private readonly IRepository<Receita> _repository;

        public ReceitaRep(IRepository<Receita> repository)
        {
            this._repository = repository;
        }
        public async Task<Receita> ObterPorId(Guid Id)
        {
            return await _repository.ObterPorId(Id);
        }

        public async Task<ICollection<Receita>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
    }
}
