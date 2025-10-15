namespace ProductAPI_backend.Repository
{
    public interface IRepository<TEntity, TId>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity?> GetById(TId id);

        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
        IEnumerable<TEntity> Search(Func<TEntity, bool> filter);
    }
}
