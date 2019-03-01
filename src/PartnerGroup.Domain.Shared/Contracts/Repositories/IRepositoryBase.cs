namespace PartnerGroup.Domain.Shared.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Remove(long id);
        void Add(TEntity item);
        void Update(TEntity item);
    }
}
