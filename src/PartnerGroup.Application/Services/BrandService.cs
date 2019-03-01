using System;
using Flunt.Notifications;
using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Contracts;
using PartnerGroup.Domain.Shared.Helpers;
using PartnerGroup.Application.Contracts;
using PartnerGroup.Application.Dtos.Brand;
using PartnerGroup.Application.Command.Brand;

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

        public BrandDto NewBrand(BrandCommand command)
        {
            if (!command.Validate())
            {
                AddNotifications(command.Notifications);
                return null;
            }

            var branch = _repositoryBrand.GetByName(command.Name);
            Assert.AssertArgumentNull(branch, "Marca já cadastrada!");
            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            var newBrand = new BrandEntity(command.Name);
            _repositoryBrand.Add(newBrand);

            return new BrandDto(0, "", true);
        }

        public BrandDto UpdateBrand(long id, BrandCommand command)
        {
            var brand = _repositoryBrand.GetById(id);
            var verifyBranch = _repositoryBrand.GetByName(command.Name);
            Assert.AssertArgumentNotNull(brand, "Nenhuma marca encontrada!");

            if (verifyBranch != null)
                Assert.AssertArgumentEquals(brand?.Id, verifyBranch?.Id, "Marca já cadastrada!");

            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            brand.Update(command.Name);
            _repositoryBrand.Update(brand);

            return new BrandDto(brand.Id, brand.Brand, brand.Active);
        }
    }
}
