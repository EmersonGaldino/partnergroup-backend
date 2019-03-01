using System;
using Flunt.Notifications;
using System.Collections.Generic;
using PartnerGroup.Application.Contracts;
using PartnerGroup.Application.Dtos.Brand;
using PartnerGroup.Application.Command.Brand;
using PartnerGroup.Domain.Contracts;

namespace PartnerGroup.Application.Services
{
    public class BrandService : Notifiable, IBrandService
    {
        private readonly IBrandRepository _repositoryBrand;
        public BrandService(IBrandRepository repositoryBrand)
        {
            _repositoryBrand = repositoryBrand;
        }

        public BrandDto Brand(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrandDto> Brands()
        {
            throw new NotImplementedException();
        }

        public BrandDto NewBrand(NewBrandCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
