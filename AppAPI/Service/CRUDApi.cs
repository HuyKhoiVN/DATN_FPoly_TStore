
using AppData.Context;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Service
{
    public class CRUDApi<T> : ICRUDApi<T> where T : class
    {
        TStoreDb _dbContext;
        DbSet<T> _dbSet;

        public CRUDApi(TStoreDb dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public bool CreateItem(T item)
        {
            try
            {
                _dbSet.Add(item);
                _dbContext.SaveChanges();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                _dbSet.Remove(item);
                _dbContext.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAllItems()
        {
            try
            {
                return _dbSet.ToList();
            }catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateItem(T item)
        {
            try
            {
                _dbSet.Update(item);
                _dbContext.SaveChanges();
                return true;
            }catch( Exception )
            {
                return false;
            }
        }
    }
}
