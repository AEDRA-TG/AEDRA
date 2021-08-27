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
    public class TraversalAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){

                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponentInChildren<ProjectedObject>();
                projectedObject.AnimationTime = 1;
                animationList.Append(projectedObject.Animations[dto.Operation]());
            }
        }
    }
}