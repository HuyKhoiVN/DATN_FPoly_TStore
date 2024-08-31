using AppAPI.Repositories;

namespace AppAPI.Service
{
    public class BaseServices<T> : IBaseServices<T> where T : class
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseServices(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            Validate(entity);
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(Guid entityId, T entity)
        {
            Validate(entity, entityId);
            return await _repository.UpdateAsync(entityId, entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        protected virtual void Validate(T entity, Guid? entityId = null)
        {

        }
    }

}
