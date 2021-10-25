using System;
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
        public static event Action<Sequence> UpdateSecuenceEvent;
        public void Animate()
        {
            int animationId = 1;
            Sequence animationList = DOTween.Sequence();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponent<ProjectedObject>();
                projectedObject.Dto.Color = dto.Color;
                projectedObject.Dto.Info = dto.Info;
                projectedObject.Dto.Step = dto.Step;

                Tween actualTween = projectedObject.Animations[dto.Operation]();
                if( actualTween != null){
                    actualTween.id = animationId;

                    if(dto.Operation == AnimationEnum.UpdateAnimation){
                        animationList.Join(actualTween);
                    }
                    else{
                        actualTween.OnComplete(()=> animationList.id = (int)actualTween.id);
                        animationList.Append(actualTween);
                        animationId++;
                    }
                }
            }

            UpdateSecuenceEvent.Invoke(animationList);
        }
    }
}