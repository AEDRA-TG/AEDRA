using DG.Tweening;
using SideCar.DTOs;
using UnityEngine;
using Utils.Enums;
using View.GUI;
using View.GUI.ProjectedObjects;

namespace View.Animations.Algorithms
{
    public class AlgorithmAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponent<ProjectedObject>();
                projectedObject.AnimationTime = 1;
                projectedObject.Dto.Color = dto.Color;
                projectedObject.Dto.Info = dto.Info;
                animationList.Append(projectedObject.Animations[dto.Operation]());
            }
            foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponent<ProjectedObject>();
                projectedObject.AnimationTime = 0;
                animationList.Append(projectedObject.UnPaintAnimation());
            }
        }
    }
}