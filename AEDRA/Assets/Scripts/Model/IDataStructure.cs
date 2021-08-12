using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Interface for defining operations of a generic Data Structure
    /// </summary>
    public interface IDataStructure
    {
        /// <summary>
        /// Method to Add an element to a data structure
        /// </summary>
        /// <param name="element"> Element to add to the data structure </param>
        public void AddElement(object element);

        /// <summary>
        /// Method to remove an element of a data structure
        /// </summary>
        /// <param name="element"> Element that will be removed of the data structure </param>
        public void DeleteElement(object element);

        /// <summary>
        /// Method to do traversal through a data structure
        /// </summary>
        /// <param name="traversalName"> Name of the traversal that will be executed on the data structure</param>
        public void DoTraversal(string traversalName);
    }
}