using Flunt.Notifications;
using System.Collections.Generic;

namespace PartnerGroup.Domain.Shared.Services
{
    public interface IServiceBase
    {
        IReadOnlyCollection<Notification> Notifications { get; }
    }
}
