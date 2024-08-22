using AppData.Context;
using AppData.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TStoreDb _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TStoreDb context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }


        // Trả về list các đối tượng theo async
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _dbSet.ToListAsync();
            return data;
        }

        // Find đối tượng, trả về đối tượng theo async
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Sử dụng try catch để bắt lỗi, thêm mới entity theo async, trả về true nếu thành công, có lỗi -> false
        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                var entityProps = entity.GetType().GetProperties();
                foreach (var prop in entityProps)
                {
                    var propName = prop.Name;

                    // Set giá trị mặc định cho trường Id
                    if (propName == "Id" && prop.PropertyType == typeof(Guid))
                    {
                        prop.SetValue(entity, Guid.NewGuid());
                    }

                    // Set giá trị mặc định cho Status
                    if (propName == "Status" && prop.PropertyType == typeof(bool))
                    {
                        prop.SetValue(entity, true);
                    }

                    // Set giá trị mặc định cho DateTime
                    if ((propName == "CreateDate" || propName == "ModifiedDate") &&
                        (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?)))
                    {
                        prop.SetValue(entity, DateTime.Now);
                    }
                }

                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return false;
            }
        }


        // Sửa đối tượng theo async
        public async Task<bool> UpdateAsync(Guid entityId, T entity)
        {
            try
            {
                var existingEntity = await _dbSet.FindAsync(entityId);
                if (existingEntity == null)
                    return false;

                var entityProps = entity.GetType().GetProperties();
                foreach (var prop in entityProps)
                {
                    var propName = prop.Name;

                    // Bỏ qua trường Id
                    if ((propName == "Id" && prop.PropertyType == typeof(Guid)) ||
                        (propName == "CreatedDate") ||
                        (propName == "CreatedBy"))
                    {
                        // Set lại giá trị ban đầu của thuộc tính
                        var originalValue = prop.GetValue(existingEntity);
                        prop.SetValue(entity, originalValue);
                    }
                }

                    _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        // Xoá 1 đối tượng theo async
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                // Tìm đối tượng bằng FindAsync,
                var entity = await _dbSet.FindAsync(id);

                // không tồn tại -> flase
                if (entity == null)
                {
                    return false;
                }
                // Tồn tại đối tượng -> xoá theo async, return true
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
