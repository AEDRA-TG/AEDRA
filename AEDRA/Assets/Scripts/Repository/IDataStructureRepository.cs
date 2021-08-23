namespace Repository
{
    public interface IDataStructureRepository<T>
    {
        /// <summary>
        /// Method to load a DataStructure instance from persistent storage
        /// </summary>
        /// <returns></returns>
        public T Load();
        /// <summary>
        /// Method to persist a Datastructure instance in memory
        /// </summary>
        /// <param name="data"></param>
        public void Save(T data);
    }
}