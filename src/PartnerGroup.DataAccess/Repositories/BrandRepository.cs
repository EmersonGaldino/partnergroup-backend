using PartnerGroup.Domain.Contracts;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Shared.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PartnerGroup.DataAccess.Repositories
{
    public class BrandRepository : IRepositoryBase<BrandEntity>, IBrandRepository
    {
        public void Add(BrandEntity item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrandEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrandEntity> GetAll(Expression<Func<BrandEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public BrandEntity GetById<T>(T id)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T id)
        {
            throw new NotImplementedException();
        }

        public void Update(BrandEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
