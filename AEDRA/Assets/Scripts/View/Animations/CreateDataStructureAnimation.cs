using DG.Tweening;
using SideCar.DTOs;
using UnityEngine;
using Utils;
using View.GUI;
using View.GUI.ProjectedObjects;

namespace View.Animations
{
    /// <summary>
    /// Strategy responsible of creating a datastructure
    /// </summary>
    internal class CreateDataStructureAnimation : IAnimationStrategy
    {
        public void Animate()
        {
            Sequence animationList = DOTween.Sequence();
            StructureProjection structureProjection = GameObject.FindObjectOfType<StructureProjection>();
            foreach (ElementDTO dto in structureProjection.DTOs)
            {
                //TODO: check this logic
                ProjectedObject obj = structureProjection.CreateObject(dto);
                if(obj.GetType() == typeof(ProjectedNode)){
                    Vector3 coordinates = new Vector3(dto.Coordinates.X, dto.Coordinates.Z, dto.Coordinates.Y);
                    Debug.Log("Cor: " + coordinates);
                    obj.Move(coordinates);
                }
                obj.IsCreated = true;
                //TODO: review how to change this value
                obj.AnimationTime = 0;
                animationList.Append(obj.Animations[dto.Operation]());
                obj.AnimationTime = Constants.AnimationTime;
            }
        }
    }
}