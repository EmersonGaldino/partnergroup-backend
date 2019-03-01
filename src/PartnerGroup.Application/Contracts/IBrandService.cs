using System.Collections.Generic;
using PartnerGroup.Application.Dtos.Brand;
using PartnerGroup.Domain.Shared.Services;
using PartnerGroup.Application.Command.Brand;
using PartnerGroup.Application.Dtos.Patrimony;

namespace PartnerGroup.Application.Contracts
{
    public interface IBrandService : IServiceBase
    {
        IEnumerable<BrandDto> Brands();
        BrandDto Brand(long id);
        IEnumerable<PatrimonyDto> PatrimonyByBrandId(long brandId);
        BrandDto NewBrand(BrandCommand command);
        BrandDto UpdateBrand(long id, BrandCommand command);
        BrandDto DeleteBrand(long id);
    }
}
