using SideCar.DTOs;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;
using Utils.Enums;

namespace View.GUI
{
    public class ProjectedObject : MonoBehaviour
    {
        public Dictionary<AnimationEnum, Func<Tween>> Animations{get; set;}

        private DataStructureElementDTO _dto;

        public void Awake(){
            Animations = new Dictionary<AnimationEnum, Func<Tween>> {
                {AnimationEnum.CreateAnimation, CreateAnimation},
                {AnimationEnum.DeleteAnimation, DeleteAnimation},
                {AnimationEnum.PaintAnimation, PaintAnimation}
            };
        }

        private Tween CreateAnimation(){
            return null;
        }

        private Tween DeleteAnimation(){
            return gameObject.transform.DOScale(new Vector3(0,0,0), 3);
        }

        private Tween PaintAnimation(){
            return null;
        }
        public void SetDTO(DataStructureElementDTO dto){
            _dto = dto;
            //TODO: update object properties
        }

        public void Move(Vector3 coordinates){
            gameObject.transform.localPosition = coordinates;
        }

        // TODO hacer un comparador
    }
}