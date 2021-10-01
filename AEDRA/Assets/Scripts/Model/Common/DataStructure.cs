using System;
using SideCar.DTOs;
using Utils.Enums;

namespace Model.Common
{
    /// <summary>
    /// Abstract class for defining operations of a generic Data Structure
    /// </summary>
    public abstract class DataStructure
    {
        /// <summary>
        /// Observer event to notify that an element of the datastructure has been updated
        /// </summary>
        public static event Action<ElementDTO> UpdateElementEvent;

        /// <summary>
        /// Method to create the datastructure
        /// </summary>
        public abstract void CreateDataStructure();

        /// <summary>
        /// Method to Add an element to a data structure
        /// </summary>
        /// <param name="element"> Element to add to the data structure </param>
        public abstract void AddElement(ElementDTO element);

        /// <summary>
        /// Method to update an element of a data structure
        /// </summary>
        /// <param name="element"> Element to update</param>
        public abstract void UpdateElement(ElementDTO element);

        /// <summary>
        /// Method to remove an element of a data structure
        /// </summary>
        /// <param name="element"> Element that will be removed of the data structure </param>
        public abstract void DeleteElement(ElementDTO element);

        /// <summary>
        /// Method to do traversal through a data structure
        /// </summary>
        /// <param name="traversalName"> Name of the traversal that will be executed on the data structure</param>
        /// <param name="data">Optional parameter with the required data to execute the traversal</param>
        public abstract void DoTraversal(TraversalEnum traversalName, ElementDTO data = null);

        /// <summary>
        /// Method to do algorithm on a data structure
        /// </summary>
        /// <param name="algorithmName">Name of the algorithm that will be executed on the data structure</param>
        /// <param name="data">Optional parameter with the required data to execute the algorithm</param>
        public abstract void DoAlgorithm(AlgorithmEnum algorithmName, ElementDTO data = null);

        /// <summary>
        /// Method to Notify observer that the specified operation has completed execution
        /// </summary>
        /// <param name="element"> Element that was modified</param>
        public static void Notify(ElementDTO element){
            UpdateElementEvent?.Invoke(element);
        }
    }
}