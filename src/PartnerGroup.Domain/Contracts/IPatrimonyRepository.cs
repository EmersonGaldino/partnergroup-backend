using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Shared.Contracts.Repositories;

namespace PartnerGroup.Domain.Contracts
{
    public interface IPatrimonyRepository : IRepositoryBase<PatrimonyEntity>
    {
        PatrimonyEntity PatrimonyById(long id);
        IEnumerable<PatrimonyEntity> Patrimonies();
        IEnumerable<PatrimonyEntity> PatrimonyByBrandId(long brandId);
    }
}