using SideCar.DTOs;
using UnityEngine;
using DG.Tweening;

namespace View.GUI
{
    public class ProjectedObject : MonoBehaviour
    {
        private DataStructureElementDTO _dto;
        public void SetDTO(DataStructureElementDTO dto){
            _dto = dto;
            //TODO: update object properties
        }

        public void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }

        public Tween Remove(){
            Tween animation = gameObject.transform.DOScale(new Vector3(0,0,0), 3).OnComplete(() => Destroy(gameObject));
            return animation;
        }

        // TODO hacer un comparador
    }
}