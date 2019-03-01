using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PartnerGroup.Domain.Shared.Contracts.Repositories;

namespace PartnerGroup.Domain.Shared.Repositories
{
    public abstract class RepositoryDapperBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public RepositoryDapperBase()
        {

        }

        public TEntity GetById<T>(T id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T id)
        {
            throw new NotImplementedException();
        }
    }
}
