using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Data.Context;
using EstaparGarage.Bussinees.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace EstaparGarage.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly EstaparDbcontext _context;
        protected readonly DbSet<TEntity> _DbSet;

        public Repository(EstaparDbcontext db)
        {
            _context = db;
            _DbSet = db.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            _context.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            _DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
