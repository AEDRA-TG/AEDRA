using Model.Common;
using Utils.Enums;
using SideCar.DTOs;
using System.Collections.Generic;

namespace Controller
{
    /// <summary>
    /// Class to manage the algorithm command
    /// </summary>
    public class DoAlgorithmCommand : Command
    {
        /// <summary>
        /// Data structure that will do the algorithm
        /// </summary>
        private DataStructure _dataStructure;

        /// <summary>
        /// Element that contains necessary algorithm information
        /// </summary>
        private List<ElementDTO> _elementDTOs;

        /// <summary>
        /// Name of the algorithm that will be executed
        /// </summary>
        private AlgorithmEnum _algorithmName;

        /// <summary>
        /// Command to make an algorithm on the data structure
        /// </summary>
        /// <param name="algorithmName">Name of the algorithm that will be executed</param>
        /// <param name="elementDTO">Information needed to execute the algorithm</param>
        public DoAlgorithmCommand(AlgorithmEnum algorithmName, List<ElementDTO> elementDTOs){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._algorithmName = algorithmName;
            this._elementDTOs = elementDTOs;
        }

        public override void Execute()
        {
            this._dataStructure.DoAlgorithm(this._algorithmName, this._elementDTOs);
            base.Notify(OperationEnum.Algorithm);
        }
    }
}