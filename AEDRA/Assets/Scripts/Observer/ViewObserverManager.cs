using System.Collections.Generic;
using Controller;
using Model.Common;
using Model.SideCar.DTOs;
using UnityEngine;
using Utils.Enums;
using View.GUI;

namespace Observer
{
    public class ViewObserverManager: MonoBehaviour
    {

        public void OnEnable(){
            // Projection subscribes to Update element event for updating UI
            DataStructure.UpdateElement += UpdateUI;
            Command.OperationCompleted += ExecuteAnimation;
        }

        public void OnDisable(){
            // Projection unsubscribes from Update Element event for updating UI
            DataStructure.UpdateElement -= UpdateUI;
            Command.OperationCompleted -= ExecuteAnimation;
        }
        /// <summary>
        /// Method to update the projection on UI
        /// </summary>
        /// <param name="element">Element that will be updated on UI</param>
        private void UpdateUI(DataStructureElementDTO dto){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.AddDto(dto);
        }

        private void ExecuteAnimation(OperationEnum operation){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.Animate(operation);
        }
    }
}