using System;
using Model.Common;
using Repository;
using Utils.Enums;
using SideCar.DTOs;

namespace Controller
{
    public class DoTraversalCommand : Command
    {
        /// <summary>
        /// Data structure that will receive the new element
        /// </summary>
        private DataStructure _dataStructure;

        /// <summary>
        /// Elements that will be connected on the data structure
        /// </summary>
        private ElementDTO _startNodeDTO;

        private string _traversalName;

        /// <summary>
        /// Command to connect two elements with an edge
        /// </summary>
        /// <param name="edgeDTO">EdgeDTO with the necesary information to connect the elements</param>
        public DoTraversalCommand(string traversalName, ElementDTO startNodeDTO){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._traversalName = traversalName;
            this._startNodeDTO = startNodeDTO;
        }
        public override void Execute()
        {
            this._dataStructure.DoTraversal(this._traversalName, this._startNodeDTO);
            //base.Notify(OperationEnum.TraversalObjects);
        }
    }
}