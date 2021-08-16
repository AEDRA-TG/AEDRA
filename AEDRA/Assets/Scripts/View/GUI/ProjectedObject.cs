using Model.SideCar.DTOs;
using UnityEngine;

namespace View.GUI
{
    public class ProjectedObject : MonoBehaviour
    {
        private DataStructureElementDTO _dto;
        public void SetDTO(DataStructureElementDTO dto){
            _dto = dto;
            //TODO: update object properties
        }
    }
}