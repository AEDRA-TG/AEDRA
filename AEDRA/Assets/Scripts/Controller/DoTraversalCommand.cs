using Model.Common;
using Utils.Enums;
using SideCar.DTOs;

namespace Controller
{
    /// <summary>
    /// Class to manage the traversal command
    /// </summary>
    public class DoTraversalCommand : Command
    {
        /// <summary>
        /// Data structure that will do the traversal
        /// </summary>
        private DataStructure _dataStructure;

        /// <summary>
        /// Element from which traversal will start if needed
        /// </summary>
        private ElementDTO _startNodeDTO;

        /// <summary>
        /// Name of the traversal that will be executed
        /// </summary>
        private TraversalEnum _traversalName;

        /// <summary>
        /// Command to make a traversal on the data structure
        /// </summary>
        /// <param name="traversalName"> Name of the traversal</param>
        /// <param name="startNodeDTO"> Information about the start element of the traversal </param>
        public DoTraversalCommand(TraversalEnum traversalName, ElementDTO startNodeDTO){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._traversalName = traversalName;
            this._startNodeDTO = startNodeDTO;
        }
        public override void Execute()
        {
            this._dataStructure.DoTraversal(this._traversalName, this._startNodeDTO);
            base.Notify(OperationEnum.TraversalObjects);
        }
    }
}