using System;
using Model.Common;

namespace Repository
{
    /// <summary>
    /// Class to define repository operations for all structures
    /// </summary>
    public abstract class DataStructureRepository
    {
        /// <summary>
        /// Event to notify the view
        /// </summary>
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

        public abstract void CleanInstance();

        /// <summary>
        /// Method that notifies view when the data structure was cleaned
        /// </summary>
        protected void Notify(){
            CleanStructure?.Invoke();
        }
    }
}