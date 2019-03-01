using System;
using PartnerGroup.Domain.Shared.ValueObjects;

namespace PartnerGroup.Domain.Entities
{
    public class PatrimonyEntity : EntityBaseValueObject<long>
    {
        public PatrimonyEntity(long brandId, string patrimony, string description)
        {
            this.BrandId = brandId;
            this.Patrimony = patrimony;
            this.Description = description;
            this.NumberTumble = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
        }

        public PatrimonyEntity(BrandEntity brand, long id, long brandId, string patrimony, string description, string numberTumble,
                               DateTime dateRegister, DateTime? dateChange, bool active)
        {
            this.BrandId = brandId;
            this.Brand = brand;
            this.Patrimony = patrimony;
            this.Description = description;
            this.NumberTumble = numberTumble;
            this.SetId(id);
            this.SetDateRegister(dateRegister);
            this.SetDateChange(dateChange);
            this.SetActive(active);
        }

        public long BrandId { get; private set; }
        public virtual BrandEntity Brand { get; private set; }

        public string Patrimony { get; private set; }
        public string Description { get; private set; }
        public string NumberTumble { get; private set; }

        public void Update(long brandId, string patrimony, string description)
        {
            this.BrandId = brandId;
            this.Patrimony = patrimony;
            this.Description = description;

            base.UpdateDataChange();
        }
    }
}
