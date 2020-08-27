using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Models;

namespace minhareceita.domain.Interfaces
{
    public interface IReceitaService
    {
        Task<int> Adicionar(Receita receita);
        Task<int> Atualizar(Receita receita);
        Task<int> Deletar(Guid Id);
    }
}
