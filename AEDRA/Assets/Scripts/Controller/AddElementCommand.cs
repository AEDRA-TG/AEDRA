using Model.Common;
using SideCar.DTOs;
using Utils.Enums;

namespace Controller
{
    /// <summary>
    /// Class to manage the add element command
    /// </summary>
    public class AddElementCommand : Command
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
        /// Method to create a new Add Object command
        /// </summary>
        /// <param name="element"> Instance of the element to add on the data structure </param>
        public AddElementCommand(ElementDTO element){
            this._dataStructure = CommandController.GetInstance().Repository.Load();
            this._element = element;
        }

        public override void Execute()
        {
            this._dataStructure.AddElement(_element);
            base.Notify(OperationEnum.AddObject);
        }
    }
}