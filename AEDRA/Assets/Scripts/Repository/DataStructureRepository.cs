using System;
using Model.Common;

namespace Repository
{
    public abstract class DataStructureRepository
    {
        public static event Action CleanStructure;
        /// <summary>
        /// Method to load a DataStructure instance from persistent storage
        /// </summary>
        /// <returns></returns>
        public abstract DataStructure Load();
        /// <summary>
        /// Method to persist a Datastructure instance in memory
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Method to erase all data from the loaded datastructure
        /// </summary>
        public abstract void Clean();

        protected void Notify(){
            CleanStructure?.Invoke();
        }
    }
}