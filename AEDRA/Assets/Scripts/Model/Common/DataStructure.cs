using System;
using Model.SideCar.DTOs;

namespace Model.Common
{
    /// <summary>
    /// Interface for defining operations of a generic Data Structure
    /// </summary>
    public abstract class DataStructure
    {
        /// <summary>
        /// TODOOOOO
        /// </summary>
        public static event Action<DataStructureElementDTO> UpdateElement;

        /// <summary>
        /// Method to Add an element to a data structure
        /// </summary>
        /// <param name="element"> Element to add to the data structure </param>
        public abstract void AddElement(object element);

        /// <summary>
        /// Method to remove an element of a data structure
        /// </summary>
        /// <param name="element"> Element that will be removed of the data structure </param>
        public abstract void DeleteElement(object element);

        /// <summary>
        /// Method to do traversal through a data structure
        /// </summary>
        /// <param name="traversalName"> Name of the traversal that will be executed on the data structure</param>
        public abstract void DoTraversal(string traversalName);

        public void Notify(DataStructureElementDTO element){
            UpdateElement?.Invoke(element);
        }
    }
}