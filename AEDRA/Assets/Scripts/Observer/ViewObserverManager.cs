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
    /// <summary>
    /// Class that receives all the model notifications
    /// </summary>
    public class ViewObserverManager: MonoBehaviour
    {
        /// <summary>
        /// Projection subscribes to Update element event for updating UI
        /// </summary>
        public void OnEnable(){
            DataStructure.UpdateElementEvent += UpdateUI;
            Command.OperationCompleted += ExecuteAnimation;
            Command.OperationCompleted += SaveDataStructure;
            Command.OperationCompleted += CleanUserSelection;
            DataStructureRepository.CleanStructure += CleanDataStructure;
        }

        /// <summary>
        /// Projection unsubscribes from Update Element event for updating UI
        /// </summary>
        public void OnDisable(){
            DataStructure.UpdateElementEvent -= UpdateUI;
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
            if(operation != OperationEnum.UpdateObjects){
                SelectionController selectionController = FindObjectOfType<SelectionController>();
                selectionController.DeselectAllObjects();
            }
        }

        /// <summary>
        /// Method to clean all the projection elements
        /// </summary>
        public void CleanDataStructure(){
            GameObject projection = GameObject.FindObjectOfType<StructureProjection>()?.gameObject;
            if(projection != null){
                Transform target = projection.transform.parent;
                Destroy(projection);

                projection = new GameObject(Constants.ObjectsParentName, typeof(StructureProjection));
                projection.transform.parent = target;
                projection.transform.localScale = Vector3.one;
                projection.transform.localRotation = Quaternion.Euler(0,0,0);
                projection.transform.localPosition = Vector3.zero;
            }
        }

        /// <summary>
        /// Method to show a text when is required
        /// </summary>
        /// <param name="notificationText"></param>
        private void CreateNotification(string notificationText){
            //StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            //projection.ShowNotification(notificationText);
        }
    }
}