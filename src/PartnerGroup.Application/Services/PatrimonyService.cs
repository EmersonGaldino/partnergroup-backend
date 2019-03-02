using System.Linq;
using Flunt.Notifications;
using System.Collections.Generic;
using PartnerGroup.Domain.Entities;
using PartnerGroup.Domain.Contracts;
using PartnerGroup.Domain.Shared.Helpers;
using PartnerGroup.Application.Converters;
using PartnerGroup.Application.Contracts;
using PartnerGroup.Application.Dtos.Patrimony;
using PartnerGroup.Application.Command.Patrimony;

namespace PartnerGroup.Application.Services
{
    public class PatrimonyService : Notifiable, IPatrimonyService
    {
        private readonly IBrandRepository _repositoryBrand;
        private readonly IPatrimonyRepository _repositoryPatrimony;
        public PatrimonyService(IBrandRepository repositoryBrand, IPatrimonyRepository repositoryPatrimony)
        {
            _repositoryBrand = repositoryBrand;
            _repositoryPatrimony = repositoryPatrimony;
        }

        public IEnumerable<PatrimonyDto> Patrimonies()
        {
            var patrimonies = _repositoryPatrimony.Patrimonies()?.ToListDto();
            return patrimonies;
        }

        public PatrimonyDto PatrimonyById(long id)
        {
            var patrimony = _repositoryPatrimony.PatrimonyById(id);
            Assert.AssertArgumentNotNull(patrimony, "Nenhum patrimônio encontrado!");
            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            return patrimony.ToDto();
        }

        public PatrimonyDto NewPatrimony(PatrimonyCommand command)
        {
            if (!command.Validate())
            {
                AddNotifications(command.Notifications);
                return null;
            }

            var verifyBrand = _repositoryBrand.GetById(command.BrandId);
            Assert.AssertArgumentNotNull(verifyBrand, "Nenhuma marca encontrada!");

            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            var newPatrimony = new PatrimonyEntity(verifyBrand.Id, command.Name, command.Description);
            _repositoryPatrimony.Add(newPatrimony);

            var lastPatrimony = Patrimonies()?.LastOrDefault();
            return lastPatrimony;
        }

        public PatrimonyDto UpdatePatrimony(long id, PatrimonyCommand command)
        {
            if (!command.Validate())
            {
                AddNotifications(command.Notifications);
                return null;
            }

            var verifyBrand = _repositoryBrand.GetById(command.BrandId);
            var patrimony = _repositoryPatrimony.PatrimonyById(id);
            Assert.AssertArgumentNotNull(verifyBrand, "Nenhuma marca encontrada!");
            Assert.AssertArgumentNotNull(patrimony, "Nenhum patrimônio encontrado!");

            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            patrimony.Update(verifyBrand.Id, command.Name, command.Description);
            _repositoryPatrimony.Update(patrimony);

            var updatePatrimony = _repositoryPatrimony.PatrimonyById(id);
            return updatePatrimony.ToDto();
        }

        public PatrimonyDto DeletePatrimony(long id)
        {
            var patrimony = _repositoryPatrimony.PatrimonyById(id);
            Assert.AssertArgumentNotNull(patrimony, "Nenhum patrimônio encontrado!");

            if (!Assert.IsValid())
            {
                AddNotifications(Assert.ListNotifications());
                return null;
            }

            _repositoryPatrimony.Remove(patrimony.Id);

            return patrimony.ToDto();
        }
    }
}
