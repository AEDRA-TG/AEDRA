namespace Repository
{
    public interface IDataStructureRepository<T>
    {
        public T Load();
        public void Save(T data);
    }
}