using System.Collections.Generic;
using PartnerGroup.Domain.Shared.Services;
using PartnerGroup.Application.Dtos.Patrimony;
using PartnerGroup.Application.Command.Patrimony;

namespace PartnerGroup.Application.Contracts
{
    public interface IPatrimonyService : IServiceBase
    {
        IEnumerable<PatrimonyDto> Patrimonies();
        PatrimonyDto PatrimonyById(long id);
        PatrimonyDto NewPatrimony(PatrimonyCommand command);
        PatrimonyDto UpdatePatrimony(long id, PatrimonyCommand command);
        PatrimonyDto DeletePatrimony(long id);
    }
}
