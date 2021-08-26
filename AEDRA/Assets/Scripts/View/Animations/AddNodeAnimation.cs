using DG.Tweening;
using SideCar.DTOs;
using UnityEngine;
using Utils.Enums;
using View.GUI;
using View.GUI.ProjectedObjects;

namespace View.Animations
{
    /// <summary>
    /// Strategy that animates the operation of adding a node to a datastructure
    /// </summary>
    public class AddNodeAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in projection.DTOs)
            {
                ProjectedObject projectedObject;
                if(dto.Operation == AnimationEnum.CreateAnimation){
                    projectedObject = projection.CreateObject(dto);
                }else{
                    projectedObject = GameObject.Find(dto.GetUnityId()).GetComponentInChildren<ProjectedObject>();
                }
                animationList.Append(projectedObject.Animations[dto.Operation]());
            }
        }
    }
}