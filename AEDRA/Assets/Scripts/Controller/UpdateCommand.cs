
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
        private ElementDTO _data;

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