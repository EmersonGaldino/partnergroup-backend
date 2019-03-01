namespace PartnerGroup.Domain.Shared.Contracts
{
    public interface IIdentity<T>
    {
        T Id { get; }
    }
}
