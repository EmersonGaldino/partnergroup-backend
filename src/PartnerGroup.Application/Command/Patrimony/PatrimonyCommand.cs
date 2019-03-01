using Flunt.Validations;
using Flunt.Notifications;
using PartnerGroup.Domain.Shared.Commands;

namespace PartnerGroup.Application.Command.Patrimony
{
    public class PatrimonyCommand : Notifiable, ICommandBase
    {
        public string BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, nameof(Name), "O Nome é obrigatório!")
                .IsNotNullOrEmpty(Description, nameof(Description), "A Descrição é obrigatória!"));

            return Valid;
        }
    }
}