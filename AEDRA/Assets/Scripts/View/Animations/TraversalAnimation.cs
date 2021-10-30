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
                projectedObject.Dto.Info = dto.Info;
                projectedObject.Dto.Step = dto.Step;
                Tween actualTween = projectedObject.Animations[dto.Operation]();
                if(actualTween != null){
                    actualTween.id = animationId;
                    actualTween.OnComplete(()=> animationList.id = (int)actualTween.id);
                    animationList.Append(actualTween);
                    if(animationId == structureProjection.DTOs.Count){
                        Tween finalTween = projectedObject.Animations[dto.Operation]();
                        finalTween.id = animationId;
                        finalTween.OnComplete(()=> animationList.id = (int)finalTween.id);
                        animationList.Append(finalTween);
                    }
                    animationId++;
                }
            }
            UpdateSecuenceEvent.Invoke(animationList);
        }
    }
}