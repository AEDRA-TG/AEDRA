using Controller;
using Model.Common;
using Repository;
using SideCar.DTOs;
using UnityEngine;
using Utils;
using Utils.Enums;
using View.EventController;
using View.GUI;

namespace Observer
{
    public class ViewObserverManager: MonoBehaviour
    {

        public void OnEnable(){
            // Projection subscribes to Update element event for updating UI
            DataStructure.UpdateElement += UpdateUI;
            Command.OperationCompleted += ExecuteAnimation;
            Command.OperationCompleted += SaveDataStructure;
            Command.OperationCompleted += CleanUserSelection;
            DataStructureRepository.CleanStructure += CleanDataStructure;
        }

        public void OnDisable(){
            // Projection unsubscribes from Update Element event for updating UI
            DataStructure.UpdateElement -= UpdateUI;
            Command.OperationCompleted -= ExecuteAnimation;
            Command.OperationCompleted -= SaveDataStructure;
            Command.OperationCompleted -= CleanUserSelection;
            DataStructureRepository.CleanStructure -= CleanDataStructure;
        }
        /// <summary>
        /// Method to update the projection on UI
        /// </summary>
        /// <param name="dto">Element that will be updated on UI</param>
        private void UpdateUI(ElementDTO dto){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.AddDto(dto);
        }
        /// <summary>
        /// Method to execute an animation
        /// </summary>
        /// <param name="operation">Animation type that will be executed</param>
        private void ExecuteAnimation(OperationEnum operation){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.Animate(operation);
        }

        /// <summary>
        /// Method to save each modification done to the DataStructure
        /// </summary>
        /// <param name="operation"></param>
        private void SaveDataStructure(OperationEnum operation){
            Command command = new SaveCommand();
            CommandController.GetInstance().Invoke(command);
        }

        /// <summary>
        /// Method to clean the previous user selection in screen
        /// </summary>
        /// <param name="operation"></param>
        private void CleanUserSelection(OperationEnum operation){
            SelectionController selectionController = FindObjectOfType<SelectionController>();
            selectionController.DeselectAllObjects();
        }

        public void CleanDataStructure(){
            GameObject projection = GameObject.FindObjectOfType<StructureProjection>()?.gameObject;
            if(projection != null){
                Transform target = projection.transform.parent;
                Destroy(projection);

                projection = new GameObject(Constants.ObjectsParentName, typeof(StructureProjection));
                projection.transform.parent = target;
            }
        }
        //TODO: Revisar de que forma manejar estos mensajes
        private void CreateNotification(string notificationText){
            //StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            //projection.ShowNotification(notificationText);
        }
    }
}