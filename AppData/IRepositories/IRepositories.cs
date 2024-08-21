
    public interface IRepositories<T>
    {
        public bool CreateItem(T item);
        public bool DeleteItem(T item);
        public IEnumerable<T> GetAllItems();
        public bool UpdateItem(T item);
    }
