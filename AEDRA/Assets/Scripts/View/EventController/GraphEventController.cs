using UnityEngine;
using Controller;
using Model.Graph;

namespace View.EventController
{
    public class GraphEventController : MonoBehaviour
    {
        public void OnTouchAddNode(){
            AddObjectCommand addCommand = new AddObjectCommand(new Graph(), "Nuevo nodo");
            CommandController.GetInstance().Invoke(addCommand);
        }
    }
}