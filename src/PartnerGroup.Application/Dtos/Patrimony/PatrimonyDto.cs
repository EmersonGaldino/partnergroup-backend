using PartnerGroup.Application.Dtos.Brand;

namespace PartnerGroup.Application.Dtos.Patrimony
{
    public class PatrimonyDto
    {
        public PatrimonyDto(long id, string patrimony, string description, string numberTumble, bool active, BrandDto brand)
        {
            Id = id;
            Patrimony = patrimony;
            Description = description;
            NumberTumble = numberTumble;
            Active = active;
            Brand = brand;
        }

        public long Id { get; private set; }
        public string Patrimony { get; private set; }
        public string Description { get; private set; }
        public string NumberTumble { get; private set; }
        public bool Active { get; private set; }
        public BrandDto Brand { get; private set; }
    }
}