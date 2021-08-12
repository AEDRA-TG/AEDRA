using System;
using System.Collections.Generic;
using Model;

namespace Controller
{
    /// <summary>
    /// Class to manage the add object command
    /// </summary>
    public class AddObjectCommand : ICommand
    {
        /// <summary>
        /// Data structure that will receive the new element
        /// </summary>
        private IDataStructure _dataStructure;

        /// <summary>
        /// Element that will be added on the data structure
        /// </summary>
        private object _element;

        /// <summary>
        /// Method to create a new Add Object command
        /// </summary>
        /// <param name="dataStructure"> Instance of the data structure that will receive the new element </param>
        /// <param name="element"> Instance of the element to add on the data structure </param>
        public AddObjectCommand(IDataStructure dataStructure, object element){
            this._dataStructure = dataStructure;
            this._element = element;
        }

        /// <summary>
        /// Method to delegate the add operation to the business logic
        /// </summary>
        public void Execute()
        {
            // TODO Load from repository
            this._dataStructure.AddElement(_element);
        }
    }
}