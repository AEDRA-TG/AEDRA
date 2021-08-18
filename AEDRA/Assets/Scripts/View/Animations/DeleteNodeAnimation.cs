using View.GUI;
using UnityEngine;
using SideCar.DTOs;
using System.Collections.Generic;
using DG.Tweening;

namespace View.Animations
{
    public class DeleteNodeAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            List<Tween> animationList = new List<Tween>();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (DataStructureElementDTO dto in structureProjection.DTOs)
            {
                string unityId = "Node_" + dto.Id;
                ProjectedObject projectedObject = GameObject.Find(unityId).GetComponentInChildren<ProjectedObject>();
                animationList.Add(projectedObject.Remove());
            }
        }
    }
}