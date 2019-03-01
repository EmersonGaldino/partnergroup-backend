using System;
using PartnerGroup.Domain.Shared.Contracts;

namespace PartnerGroup.Domain.Shared.ValueObjects
{
    public class IdentityValueObject<TId> : IIdentity<TId>
    {
        public TId Id { get; private set; }
        public IdentityValueObject(TId id)
        {
            Id = id;
        }

        public IdentityValueObject()
        {
            if (typeof(TId) == typeof(string))
            {
                Id = (TId)(object)Guid.NewGuid().ToString();
            }
        }

        public void SetId(TId id)
        {
            Id = id;
        }
    }
}
