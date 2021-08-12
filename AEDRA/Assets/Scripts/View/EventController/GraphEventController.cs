using UnityEngine;
using Controller;
using Model.Graph;

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
        public void OnTouchAddNode(){
            AddObjectCommand addCommand = new AddObjectCommand(new Graph(), "Nuevo nodo");
            CommandController.GetInstance().Invoke(addCommand);
        }
    }
}