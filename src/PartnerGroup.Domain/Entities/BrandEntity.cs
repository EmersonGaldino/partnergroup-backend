using PartnerGroup.Domain.Shared.ValueObjects;

namespace PartnerGroup.Domain.Entities
{
    public class BrandEntity : EntityBaseValueObject<long>
    {
        public BrandEntity(string brand)
        {
            Brand = brand;
        }

        public string Brand { get; private set; }

        public void Update(string brand)
        {
            Brand = brand;

            base.UpdateDataChange();
        }
    }
}
