namespace ProductAPI_backend.Services
{
    public interface ICommonService<T, TI, TU, TId>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<T?> GetById(TId id);

        Task<T> Add(TI skateInsertDto);
        Task<T> Update(TId id, TU skateUpdateDto);
        Task<T> Delete(TId id);

        bool Validate(TI insertDto);
        bool Validate(TU updateDto);
    }

}
