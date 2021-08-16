using System.Collections.Generic;
using Model.Common;
using Model.SideCar.DTOs;
using UnityEngine;
using View.GUI;

namespace Observer
{
    public class ViewObserverManager: MonoBehaviour
    {

        public void OnEnable(){
            // Projection subscribes to Update element event for updating UI
            DataStructure.UpdateElement += UpdateUI;
        }

        public void OnDisable(){
            // Projection unsubscribes from Update Element event for updating UI
            DataStructure.UpdateElement -= UpdateUI;
        }
        /// <summary>
        /// Method to update the projection on UI
        /// </summary>
        /// <param name="element">Element that will be updated on UI</param>
        private void UpdateUI(DataStructureElementDTO dto){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.AddDto(dto);
        }
    }
}