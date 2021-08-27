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
        public void OnTargetDetected(){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.Name = "Graph";
            Command command = new LoadCommand(projection.Name);
            CommandController.GetInstance().Invoke(command);
        }

        public void OnTargetLost(){
            Command command = new SaveCommand();
            CommandController.GetInstance().Invoke(command);
        }
    }
}