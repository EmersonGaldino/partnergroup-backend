using System.Linq;
using Flunt.Notifications;
using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Contracts;
using PartnerGroup.Application.Converters;
using PartnerGroup.Domain.Shared.Helpers;
using PartnerGroup.Application.Contracts;
using PartnerGroup.Application.Dtos.Brand;
using PartnerGroup.Application.Command.Brand;
using PartnerGroup.Application.Dtos.Patrimony;

namespace PartnerGroup.Application.Services
{
    public class BrandService : Notifiable, IBrandService
    {
        private readonly IBrandRepository _repositoryBrand;
        private readonly IPatrimonyRepository _repositoryPatrimony;
        public BrandService(IBrandRepository repositoryBrand, IPatrimonyRepository repositoryPatrimony)
        {
            _repositoryBrand = repositoryBrand;
            _repositoryPatrimony = repositoryPatrimony;
        }

        public BrandDto Brand(long id)
        {
            var brand = _repositoryBrand.GetById(id);
            Assert.AssertArgumentNotNull(brand, "Nenhuma marca encontrada!");
            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            return new BrandDto(brand.Id, brand.Brand, brand.Active);
        }

        public IEnumerable<BrandDto> Brands()
        {
            var brands = _repositoryBrand.Brands()?.Select(x => new BrandDto(x.Id, x.Brand, x.Active));
            return brands;
        }

        public IEnumerable<PatrimonyDto> PatrimonyByBrandId(long brandId)
        {
            var patrimonies = _repositoryPatrimony.PatrimonyByBrandId(brandId)?.ToListDto();
            return patrimonies;
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

            var lastBrand = Brands()?.LastOrDefault();
            return lastBrand;
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

        public BrandDto DeleteBrand(long id)
        {
            var brand = _repositoryBrand.GetById(id);
            Assert.AssertArgumentNotNull(brand, "Nenhuma marca encontrada!");

            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            _repositoryBrand.Remove(brand.Id);

            return new BrandDto(brand.Id, brand.Brand, brand.Active);
        }
    }
}
