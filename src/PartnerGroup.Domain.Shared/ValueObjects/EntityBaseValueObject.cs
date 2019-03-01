using System;
using PartnerGroup.Domain.Shared.Helpers;

namespace PartnerGroup.Domain.Shared.ValueObjects
{
    public class EntityBaseValueObject<TId> : IdentityValueObject<TId>
    {
        public DateTime DateRegister { get; private set; } = DateTime.Now.GetBrazilianTime();
        public DateTime? DateChange { get; private set; } = null;
        public bool Active { get; private set; } = true;

        protected virtual void UpdateDataChange() => this.DateChange = DateTime.Now.GetBrazilianTime();
        protected virtual void ChangeStatus(bool status) => this.Active = status;
        protected virtual void CreateId(TId id) => base.SetId(id);
    }
}
