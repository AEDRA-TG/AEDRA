using View.GUI;
using UnityEngine;
using SideCar.DTOs;
using System.Collections.Generic;
using DG.Tweening;
using Utils.Enums;
using View.GUI.ProjectedObjects;
using Utils;

namespace View.Animations
{
    /// <summary>
    /// Strategy that animates the operation of deleting a Node from a DataStructure
    /// </summary>
    public class DeleteNodeAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            List<ProjectedObject> objectsToBeDeleted = new List<ProjectedObject>();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponentInChildren<ProjectedObject>();
                if(dto.Operation == AnimationEnum.DeleteAnimation){
                    objectsToBeDeleted.Add(projectedObject);
                    GraphNodeDTO nodeDTO = (GraphNodeDTO) dto;
                    foreach(int neighbor in nodeDTO.Neighbors){
                        string compoundName;
                        if(nodeDTO.Id < neighbor)
                        {
                            compoundName = Constants.EdgeName + nodeDTO.Id + "_" + neighbor;
                        }
                        else{
                            compoundName = Constants.EdgeName + neighbor + "_" + nodeDTO.Id;
                        }
                        ProjectedObject edgeProjectedObject = GameObject.Find(compoundName).GetComponentInChildren<ProjectedObject>();
                        objectsToBeDeleted.Add(edgeProjectedObject);
                        animationList.Join(edgeProjectedObject.Animations[AnimationEnum.DeleteAnimation]());
                    }
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