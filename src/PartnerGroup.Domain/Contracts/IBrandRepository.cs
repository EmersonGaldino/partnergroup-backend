﻿using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Shared.Contracts.Repositories;

namespace PartnerGroup.Domain.Contracts
{
    public interface IBrandRepository : IRepositoryBase<BrandEntity>
    {
        BrandEntity GetById(long id);
        BrandEntity GetByName(string name);
        IEnumerable<BrandEntity> Brands();
    }
}
