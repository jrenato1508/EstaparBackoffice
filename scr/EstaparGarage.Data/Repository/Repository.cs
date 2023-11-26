using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using EstaparGarage.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity,new()
    {
        protected readonly EstaparDbcontext _context;
        protected readonly DbSet<TEntity> _DbSet;

        public Repository(EstaparDbcontext db)
        {
            _context = db;
            _DbSet = db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
      
        public async Task<TEntity> ObeterPorId(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            _context.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
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
