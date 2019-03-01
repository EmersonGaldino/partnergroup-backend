using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace PartnerGroup.Domain.Shared.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Remove<T>(T id);
        void Add(TEntity item);
        void Update(TEntity item);
        TEntity GetById<T>(T id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
    }
}
