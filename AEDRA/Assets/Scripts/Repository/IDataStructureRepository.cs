using Model.Common;

namespace Repository
{
    public interface IDataStructureRepository
    {
        /// <summary>
        /// Method to load a DataStructure instance from persistent storage
        /// </summary>
        /// <returns></returns>
        public DataStructure Load();
        /// <summary>
        /// Method to persist a Datastructure instance in memory
        /// </summary>
        public void Save();
    }
}