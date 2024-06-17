namespace AppAPI.Service
{
    public interface ICRUDApi<T>
    {
        public bool CreateItem(T item);
        public bool DeleteItem(T item);
        public IEnumerable<T> GetAllItems();
        public bool UpdateItem(T item);
    }
}
