using System.Linq;
using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Application.Dtos.Brand;
using PartnerGroup.Application.Dtos.Patrimony;

namespace PartnerGroup.Application.Converters
{
    public static class PatrimonyConvert
    {
        public static IEnumerable<PatrimonyDto> ToListDto(this IEnumerable<PatrimonyEntity> entities)
        {
            var dto = entities.Select(j => new PatrimonyDto(j.Id, j.Patrimony, j.Description, j.NumberTumble, j.Active,
                                           new BrandDto(j.Brand.Id, j.Brand.Brand, j.Brand.Active)));
            return dto;
        }
    }
}
