using Model.Common;
using Utils.Enums;
using SideCar.DTOs;

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
        private ElementDTO _elementDTO;

        /// <summary>
        /// Name of the algorithm that will be executed
        /// </summary>
        private AlgorithmEnum _algorithmName;

        /// <summary>
        /// Command to make an algorithm on the data structure
        /// </summary>
        /// <param name="algorithmName">Name of the algorithm that will be executed</param>
        /// <param name="elementDTO">Information needed to execute the algorithm</param>
        public DoAlgorithmCommand(AlgorithmEnum algorithmName, ElementDTO elementDTO){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._algorithmName = algorithmName;
            this._elementDTO = elementDTO;
        }

        public override void Execute()
        {
            this._dataStructure.DoAlgorithm(this._algorithmName, this._elementDTO);
            base.Notify(OperationEnum.Algorithm);
        }
    }
}