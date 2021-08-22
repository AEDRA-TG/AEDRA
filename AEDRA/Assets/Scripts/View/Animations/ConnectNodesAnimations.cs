using View.GUI;
using UnityEngine;
using SideCar.DTOs;
using System.Collections.Generic;
using DG.Tweening;
using Utils.Enums;

namespace View.Animations
{
    public class ConnectNodesAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            List<ProjectedObject> objectsToBeDeleted = new List<ProjectedObject>();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                string unityId = "Node_" + dto.Id;
                ProjectedObject projectedObject = GameObject.Find(unityId).GetComponentInChildren<ProjectedObject>();
                if(dto.Operation == AnimationEnum.DeleteAnimation){
                    objectsToBeDeleted.Add(projectedObject);
                }
                animationList.Append(projectedObject.Animations[dto.Operation]());
            }
            // Obtener las conexiones del objeto a eliminar
            // Obtener las aristas de las conexiones
            // Delegar al structure projection la eliminación
            animationList.OnComplete(() => structureProjection.DeleteObject(objectsToBeDeleted));
        }
    }
}