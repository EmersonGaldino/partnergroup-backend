using Flunt.Validations;
using Flunt.Notifications;
using PartnerGroup.Domain.Shared.Commands;

namespace PartnerGroup.Application.Command.Brand
{
    public class BrandCommand : Notifiable, ICommandBase
    {
        public string Name { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, nameof(Name), "O Nome é obrigatório!"));

            return Valid;
        }
    }
}
