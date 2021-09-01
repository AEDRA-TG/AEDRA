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
                }
                if(projectedObject as ProjectedEdge && dto.Operation == AnimationEnum.DeleteAnimation)
                {
                    animationList.Join(projectedObject.Animations[dto.Operation]());
                }
                else{
                    animationList.Append(projectedObject.Animations[dto.Operation]());
                }
            }
            animationList.OnComplete(() => structureProjection.DeleteObject(objectsToBeDeleted));
        }
    }
}