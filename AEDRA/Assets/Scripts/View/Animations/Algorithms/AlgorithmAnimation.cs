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
                //projectedObject.AnimationTime = 1;
                projectedObject.Dto.Color = dto.Color;
                projectedObject.Dto.Info = dto.Info;
                Tween actualTween = projectedObject.Animations[dto.Operation]();
                actualTween.id = animationId;
                actualTween.OnStart(()=>  {
                    Transform infoGameObject = projectedObject.transform.Find("Info");
                    TextMesh info =  infoGameObject?.GetComponent<TextMesh>();
                    if(info != null){
                        info.text = dto.Info;
                    }
                });
                if(dto.Operation == AnimationEnum.UpdateAnimation && dto.Info != null){
                    animationList.Join(actualTween);
                }
                else{
                    actualTween.OnComplete(()=> animationList.id = (int)actualTween.id);
                    animationList.Append(actualTween);
                    animationId++;
                }
            }
            /*foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponent<ProjectedObject>();
                projectedObject.AnimationTime = 0;
                animationList.Append(projectedObject.UnPaintAnimation());
            }*/

            UpdateSecuenceEvent.Invoke(animationList);
        }
    }
}