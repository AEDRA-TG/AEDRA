using System;
using Model.Common;
using Repository;
using Utils.Enums;
using SideCar.DTOs;
using Model.GraphModel;

namespace Controller
{
    /// <summary>
    /// Class to manage the connect elements command
    /// </summary>
    public class ConnectElementsCommand : Command
    {
        /// <summary>
        /// Data structure that will receive the new element
        /// </summary>
        private DataStructure _dataStructure;

        /// <summary>
        /// Elements information that will be connected on the data structure
        /// </summary>
        private ElementDTO _edgeDTO;

        /// <summary>
        /// Command to connect two elements with an edge
        /// </summary>
        /// <param name="edgeDTO">EdgeDTO with the necesary information to connect the elements</param>
        public ConnectElementsCommand(ElementDTO edgeDTO){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._edgeDTO = edgeDTO;
        }
        public override void Execute()
        {
            if(this._dataStructure is Graph graph)
            {
                graph.ConnectElements(this._edgeDTO);
                base.Notify(OperationEnum.ConnectObjects);
            }
        }
    }
}