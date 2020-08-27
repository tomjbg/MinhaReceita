using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace minhareceita.domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Adicionar(T obj);
        Task<int> Atualizar(T obj);
        Task<int> Deletar(Guid Id);
        Task<ICollection<T>> ObterTodos();
        Task<T> ObterPorId(Guid Id);
        Task<ICollection<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<int> Salvar();

    }
}
