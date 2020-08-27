using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using minhareceita.domain.Interfaces;
using minhareceita.data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace minhareceita.data.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext _db;
        protected readonly DbSet<T> _dbset;

        public Repository(AppDbContext ctx)
        {
            this._db = ctx;
            this._dbset = ctx?.Set<T>();
        }

        public async Task<int> Adicionar(T obj)
        {
            _dbset.Add(obj);
            return await Salvar();
        }

        public async Task<int> Atualizar(T obj)
        {
            _dbset.Update(obj);
            return await Salvar();
        }

        public async Task<ICollection<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AsNoTracking().Where(predicate).ToListAsync().ConfigureAwait(true);
        }

        public async Task<int> Deletar(Guid Id)
        {
            _dbset.Remove(_dbset.Find(Id));
            return await Salvar();
        }


        public async Task<T> ObterPorId(Guid Id)
        {
            return await _dbset.FindAsync(Id).ConfigureAwait(true);
        }

        public async Task<ICollection<T>> ObterTodos()
        {
            return await _dbset.AsNoTracking().ToListAsync().ConfigureAwait(true);
        }

        public async Task<int> Salvar()
        {
            return await _db.SaveChangesAsync().ConfigureAwait(true);
        }


        public void Dispose()
        {
            _db?.Dispose();
        }



    }
}
