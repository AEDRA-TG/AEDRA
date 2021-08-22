using System;
using Model.Common;
using Repository;
using Utils.Enums;
using SideCar.DTOs;

namespace Controller
{
    public class DeleteElementCommand : Command
    {
        /// <summary>
        /// Data structure that will receive the new element
        /// </summary>
        private DataStructure _dataStructure;

        /// <summary>
        /// Element that will be added on the data structure
        /// </summary>
        private ElementDTO _element;

        public DeleteElementCommand(ElementDTO element){
            this._dataStructure = new GraphRepository().Load();
            this._element = element;
        }
        public override void Execute()
        {
            this._dataStructure.DeleteElement(this._element);
            base.Notify(OperationEnum.DeleteObject);
        }
    }
}