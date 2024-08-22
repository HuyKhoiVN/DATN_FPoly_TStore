namespace AppAPI.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(Guid entityId, T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
