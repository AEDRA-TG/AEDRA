using System;
using SideCar.DTOs;

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
        public static event Action<ElementDTO> UpdateElement;

        /// <summary>
        /// Method to Add an element to a data structure
        /// </summary>
        /// <param name="element"> Element to add to the data structure </param>
        public abstract void AddElement(ElementDTO element);

        /// <summary>
        /// Method to remove an element of a data structure
        /// </summary>
        /// <param name="element"> Element that will be removed of the data structure </param>
        public abstract void DeleteElement(ElementDTO element);

        /// <summary>
        /// Method to do traversal through a data structure
        /// </summary>
        /// <param name="traversalName"> Name of the traversal that will be executed on the data structure</param>
        public abstract void DoTraversal(string traversalName);
        /// <summary>
        /// Method to do connect two elements in a data structure
        /// </summary>
        /// <param name="element"> Edge that will be created in the data structure</param>
        public abstract void ConnectElements(ElementDTO edgeDTO);


        public void Notify(ElementDTO element){
            UpdateElement?.Invoke(element);
        }
    }
}