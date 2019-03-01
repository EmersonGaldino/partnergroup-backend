using System;
using PartnerGroup.Domain.Shared.ValueObjects;

namespace PartnerGroup.Domain.Entities
{
    public class BrandEntity : EntityBaseValueObject<long>
    {
        public BrandEntity(string brand)
        {
            Brand = brand;
        }

        public BrandEntity(long id, string brand, DateTime dateRegister, DateTime? dateChange, bool active)
        {
            this.SetId(id);
            this.Brand = brand;
            this.SetDateRegister(dateRegister);
            this.SetDateChange(dateChange);
            this.SetActive(active);
        }

        public string Brand { get; private set; }

        public void Update(string brand)
        {
            Brand = brand;

            base.UpdateDataChange();
        }
    }
}
