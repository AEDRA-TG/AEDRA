using SideCar.DTOs;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;
using Utils.Enums;
using Utils;

namespace View.GUI
{
    public class ProjectedObject : MonoBehaviour
    {
        public Dictionary<AnimationEnum, Func<Tween>> Animations{get; set;}

        public ElementDTO Dto{get; set;}

        public void Awake(){
            Animations = new Dictionary<AnimationEnum, Func<Tween>> {
                {AnimationEnum.CreateAnimation, CreateAnimation},
                {AnimationEnum.DeleteAnimation, DeleteAnimation},
                {AnimationEnum.PaintAnimation, PaintAnimation}
            };
        }

        private Tween CreateAnimation(){
            return gameObject.transform.DOScale(1,Constants.AnimationTime);
        }

        private Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0),Constants.AnimationTime);
        }

        private Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.red,Constants.AnimationTime);
        }
        public void SetDTO(ElementDTO dto){
            Dto = dto;
            //TODO: update object properties
        }

        public void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }

        public override bool Equals(object other)
        {
            return Equals(other as ProjectedObject);
        }

        public bool Equals(ProjectedObject other){
            return other != null &&
                Dto.Id == other.Dto.Id;
        }

        public override int GetHashCode()
        {
            //TODO: Look how to implement this method since library HashCode.Combine can't be used
            throw new NotImplementedException();
        }
    }
}