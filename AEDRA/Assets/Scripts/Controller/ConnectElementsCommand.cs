using System;
using Model.Common;
using Repository;
using Utils.Enums;
using SideCar.DTOs;

namespace Controller
{
    public class ConnectElementsCommand : Command
    {
        /// <summary>
        /// Data structure that will receive the new element
        /// </summary>
        private DataStructure _dataStructure;

        /// <summary>
        /// Elements that will be connected on the data structure
        /// </summary>
        private ElementDTO _edgeDTO;

        public ConnectElementsCommand(ElementDTO edgeDTO){
            this._dataStructure = new GraphRepository().Load();
            this._edgeDTO = edgeDTO;
        }
        public override void Execute()
        {
            this._dataStructure.ConnectElements(this._edgeDTO);
            base.Notify(OperationEnum.ConnectObjects);
        }
    }
}