using UnityEngine;
using Controller;
using Model.GraphModel;
using Utils.Enums;

namespace View.EventController
{
    /// <summary>
    /// Class to manage events received from an action executed on a graph by the user
    /// </summary>
    public class GraphEventController : MonoBehaviour
    {
        
        private CommandController controller = CommandController.GetInstance();
        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode(int data){
            AddObjectCommand addCommand = (AddObjectCommand)controller.commands[CommandEnum.AddElement];
            addCommand.Element = data;
            CommandController.GetInstance().Invoke(addCommand);
        }
    }
}