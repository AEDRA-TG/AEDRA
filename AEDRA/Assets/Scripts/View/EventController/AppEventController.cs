using Controller;
using UnityEngine;
using View.GUI;

namespace View.EventController
{
    public class AppEventController: MonoBehaviour
    {
        public void Start(){
            //TODO: Comment this line
            OnTargetDetected();
        }

        /// <summary>
        /// Method that executes when a target is detected by the camera
        /// </summary>
        public void OnTargetDetected(){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.Name = "Graph";
            Command command = new LoadCommand(projection.Name);
            CommandController.GetInstance().Invoke(command);
        }

        /// <summary>
        /// Method that executes when a target is lost by the camera
        /// </summary>
        public void OnTargetLost(){
            Command command = new SaveCommand();
            CommandController.GetInstance().Invoke(command);
        }
    }
}