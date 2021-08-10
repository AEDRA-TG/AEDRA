using System;
using System.Collections.Generic;
using Model;

namespace Controller
{
    public class AddObjectCommand : ICommand
    {
        private IDataStructure _dataStructure;
        private object _element;
        public AddObjectCommand(IDataStructure dataStructure, object element){
            this._dataStructure = dataStructure;
            this._element = element;
        }
        public void Execute()
        {
            // TODO Load from repository
            this._dataStructure.AddElement(_element);
        }
    }
}