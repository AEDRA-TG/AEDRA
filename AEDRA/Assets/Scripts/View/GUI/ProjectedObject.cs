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
        public float AnimationTime {get; set;}

        public void Awake(){
            AnimationTime = Constants.AnimationTime;
            Animations = new Dictionary<AnimationEnum, Func<Tween>> {
                {AnimationEnum.CreateAnimation, CreateAnimation},
                {AnimationEnum.DeleteAnimation, DeleteAnimation},
                {AnimationEnum.PaintAnimation, PaintAnimation}
            };
        }

        public void Update() {
            if(Dto != null){
                UpdateCoordinates();
            }
        }

        private Tween CreateAnimation(){
            return gameObject.transform.DOScale(1,AnimationTime);
        }

        private Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0),AnimationTime);
        }

        private Tween PaintAnimation(){
            MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
            return mesh.material.DOColor(Color.red,AnimationTime);
        }
        public void SetDTO(ElementDTO dto){
            Dto = dto;
            //TODO: Fix this
            Move(new Vector3(dto.Coordinates.X,dto.Coordinates.Y,dto.Coordinates.Z));
        }

        public void UpdateCoordinates(){
            Vector3 point = this.gameObject.transform.localPosition;
            Dto.Coordinates = new Point(point.x,point.y,point.z);
        }

        public void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
            UpdateCoordinates();
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