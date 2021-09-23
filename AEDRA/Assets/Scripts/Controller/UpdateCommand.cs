
using Model.Common;
using SideCar.DTOs;
using Utils.Enums;

namespace Controller
{
    /// <summary>
    /// Command to persist the state of a datastructure
    /// </summary>
    public class UpdateCommand : Command
    {
        /// <summary>
        /// Element that will be updated
        /// </summary>
        private ElementDTO _data;

        /// <summary>
        /// Command to update some element on model
        /// </summary>
        /// <param name="data">Element that will be updated</param>
        public UpdateCommand(ElementDTO data){
            this._data = data;
        }

        public override void Execute()
        {
            DataStructure dataStructure = CommandController.GetInstance().Repository.Load();
            dataStructure.UpdateElement(_data);
            base.Notify(OperationEnum.UpdateObjects);
        }
    }
}