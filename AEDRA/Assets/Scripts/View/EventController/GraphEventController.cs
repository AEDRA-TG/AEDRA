using UnityEngine;
using Controller;
using Model.GraphModel;

namespace View.EventController
{
    /// <summary>
    /// Class to manage events received from an action executed on a graph by the user
    /// </summary>
    public class GraphEventController : MonoBehaviour
    {
        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode(int data){
            AddObjectCommand addCommand = new AddObjectCommand(data);
            CommandController.GetInstance().Invoke(addCommand);
        }
    }
}