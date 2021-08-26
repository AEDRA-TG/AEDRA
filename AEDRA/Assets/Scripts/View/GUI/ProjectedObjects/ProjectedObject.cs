using SideCar.DTOs;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;
using Utils.Enums;
using Utils;

namespace View.GUI.ProjectedObjects
{
    public class ProjectedObject : MonoBehaviour
    {
        public Dictionary<AnimationEnum, Func<Tween>> Animations{get; set;}
        public ElementDTO Dto{get; set;}
        public bool IsCreated {get; set;}
        virtual public void Awake(){
            IsCreated = false;
            Animations = new Dictionary<AnimationEnum, Func<Tween>> {
                {AnimationEnum.CreateAnimation, CreateAnimation},
                {AnimationEnum.DeleteAnimation, DeleteAnimation},
                {AnimationEnum.PaintAnimation, PaintAnimation}
            };
        }

        virtual public Tween CreateAnimation(){
            return null;
        }

        virtual public Tween DeleteAnimation(){
            return null;
        }

        virtual public Tween PaintAnimation(){
            return null;
        }

        virtual public void Move(Vector3 coordinates){
        }

        virtual public void SetDTO(ElementDTO dto){
            Dto = dto;
            //TODO: update object properties
        }

        public override bool Equals(object other){
            return Equals(other as ProjectedObject);
        }

        public bool Equals(ProjectedObject other){
            return other != null &&
                Dto.Id == other.Dto.Id;
        }

        public override int GetHashCode(){
            //TODO: Look how to implement this method since library HashCode.Combine can't be used
            throw new NotImplementedException();
        }
    }
}