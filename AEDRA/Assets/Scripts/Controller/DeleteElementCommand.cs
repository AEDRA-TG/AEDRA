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
        /// <summary>
        /// Command to delete and element
        /// </summary>
        /// <param name="element">DTO with information needed to delete the element</param>
        public DeleteElementCommand(ElementDTO element){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._element = element;
        }
        public override void Execute()
        {
            this._dataStructure.DeleteElement(this._element);
            base.Notify(OperationEnum.DeleteObject);
        }
    }
}