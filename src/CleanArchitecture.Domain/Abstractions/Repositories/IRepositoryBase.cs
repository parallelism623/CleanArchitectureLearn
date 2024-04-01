﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions.Repositories
{
    public interface IRepositoryBase<TEntity, in Tkey> where TEntity : class
    {
        TEntity FindById(Tkey id, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity FindSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveMultiple(List<TEntity> entities);
    }
}
