using CleanArchitecture.Domain.Abstractions.Entities;
using CleanArchitecture.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Pesistence.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : DomainEntity<TKey>
    {
        private readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context) 
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = _context.Set<TEntity>().AsNoTracking().AsQueryable().Where(predicate);
            if (result.Any())
            {
                foreach (var property in includeProperties)
                {
                    result.Include(property);
                }
            }
            return result;
        }
        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = _context.Set<TEntity>().AsNoTracking().AsQueryable();
            if (result.Any())
            {
                foreach (var property in includeProperties)
                {
                    result.Include(property);
                }
            }
            return result;
        }
        public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await FindAll(includeProperties).SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await FindAll(includeProperties).SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }   

        public void RemoveMultiple(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

    }
}
