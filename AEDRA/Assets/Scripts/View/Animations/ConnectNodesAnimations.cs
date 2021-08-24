using View.GUI;
using UnityEngine;
using SideCar.DTOs;
using System.Collections.Generic;
using DG.Tweening;
using Utils.Enums;
using View.GUI.ProjectedObjects;

namespace View.Animations
{
    /// <summary>
    /// Strategy that animates the operation of connecting to Nodes of a Datastructure
    /// </summary>
    public class ConnectNodesAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            List<ProjectedObject> objectsToBeDeleted = new List<ProjectedObject>();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject;
                if(dto.Operation == AnimationEnum.CreateAnimation){
                    projectedObject = structureProjection.CreateObject(dto);
                }
                else{
                    projectedObject = GameObject.Find(dto.GetUnityId()).GetComponentInChildren<ProjectedObject>();
                }
                animationList.Append(projectedObject.Animations[dto.Operation]()).OnComplete(()=> projectedObject.IsCreated = true);
            }
        }
    }
}