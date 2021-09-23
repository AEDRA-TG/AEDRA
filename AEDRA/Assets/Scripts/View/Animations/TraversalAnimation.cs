using View.GUI;
using UnityEngine;
using SideCar.DTOs;
using DG.Tweening;
using View.GUI.ProjectedObjects;

namespace View.Animations
{
    /// <summary>
    /// Strategy that animates the operation of traversal a DataStructure
    /// </summary>
    public class TraversalAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs){
                ProjectedObject projectedObject = GameObject.Find(dto.GetUnityId()).GetComponent<ProjectedObject>();
                projectedObject.AnimationTime = 1;
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