using View.GUI;
using UnityEngine;
using SideCar.DTOs;
using DG.Tweening;
using View.GUI.ProjectedObjects;
using System;

namespace View.Animations
{
    /// <summary>
    /// Strategy that animates the operation of traversal a DataStructure
    /// </summary>
    public class TraversalAnimation : IAnimationStrategy
    {
        public static event Action<Sequence> UpdateSecuenceEvent;
        public void Animate()
        {
            int animationId = 1;
            Sequence animationList = DOTween.Sequence();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponent<ProjectedObject>();
                projectedObject.AnimationTime = 1;
                Tween actualTween = projectedObject.Animations[dto.Operation]();
                actualTween.id = animationId;
                actualTween.OnComplete(()=> animationList.id = (int)actualTween.id);
                animationList.Append(actualTween);
                animationId++;
            }
            UpdateSecuenceEvent.Invoke(animationList);
        }
    }
}