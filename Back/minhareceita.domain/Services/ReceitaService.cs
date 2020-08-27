using System;
using System.Threading.Tasks;
using minhareceita.domain.Interfaces;
using minhareceita.domain.Models;

namespace minhareceita.domain.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IRepository<Receita> _repository;
        public ReceitaService(IRepository<Receita> repository)
        {
            _repository = repository;
        }

        public async Task<int> Adicionar(Receita receita)
        {
            return await _repository.Adicionar(receita);
        }

        public async Task<int> Atualizar(Receita receita)
        {
            return await _repository.Atualizar(receita);
        }

        public async Task<int> Deletar(Guid Id)
        {
            return await _repository.Deletar(Id);
        }
    }
}