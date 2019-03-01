namespace PartnerGroup.Application.Dtos.Brand
{
    public class BrandDto
    {
        public BrandDto(long id, string brand, bool active)
        {
            Id = id;
            Brand = brand;
            Active = active;
        }

        public long Id { get; private set; }
        public string Brand { get; private set; }
        public bool Active { get; private set; }
    }
}
