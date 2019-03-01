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
            throw new System.NotImplementedException();
        }

        public PatrimonyDto UpdatePatrimony(long id, PatrimonyCommand command)
        {
            throw new System.NotImplementedException();
        }

        public PatrimonyDto DeletePatrimony(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
