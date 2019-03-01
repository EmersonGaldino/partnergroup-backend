using System.Collections.Generic;
using PartnerGroup.Application.Dtos.Brand;
using PartnerGroup.Domain.Shared.Services;
using PartnerGroup.Application.Command.Brand;

namespace PartnerGroup.Application.Contracts
{
    public interface IBrandService : IServiceBase
    {
        BrandDto Brand(long id);
        IEnumerable<BrandDto> Brands();
        BrandDto NewBrand(BrandCommand command);
        BrandDto UpdateBrand(long id, BrandCommand command);
    }
}
