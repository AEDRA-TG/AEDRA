using SideCar.DTOs;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;
using Utils.Enums;
using Utils;
using View.GUI.ObjectsPhysics;

namespace View.GUI.ProjectedObjects
{
    /// <summary>
    /// Base class that defines method for projected objects
    /// </summary>
    public class ProjectedObject : MonoBehaviour
    {
        /// <summary>
        /// Indicates if the object could be selected
        /// </summary>
        [SerializeField] private bool _selectable;

        /// <summary>
        /// Indicates if the projected object is selected
        /// </summary>
        private bool _selected;

        /// <summary>
        /// Dictionary that contains all the animations that could be applied to the objects
        /// </summary>
        public Dictionary<AnimationEnum, Func<Tween>> Animations { get; set; }

        /// <summary>
        /// Asociated object DTO
        /// </summary>
        public ElementDTO Dto { get; set; }

        /// <summary>
        /// Indicates if the projected object is visible for user
        /// </summary>
        /// <value>True when user can see the object, false otherwise</value>
        public bool IsCreated { get; set; }

        /// <summary>
        /// Time in seconds for each projected object animation
        /// </summary>
        public float AnimationTime{get; set;}

        /// <summary>
        /// Intance of the class physics for the projected object
        /// </summary>
        protected ObjectPhysics _objectPhysics;
        [SerializeField]
        protected TextMesh text;

        virtual public void Awake()
        {
            _objectPhysics = new ObjectPhysics(this.gameObject);
            AnimationTime = Constants.AnimationTime;
            IsCreated = false;
            Animations = new Dictionary<AnimationEnum, Func<Tween>> {
                {AnimationEnum.CreateAnimation, CreateAnimation},
                {AnimationEnum.DeleteAnimation, DeleteAnimation},
                {AnimationEnum.KeepPaintAnimation,KeepPaintAnimation},
                {AnimationEnum.UnPaintAnimation, UnPaintAnimation},
                {AnimationEnum.PaintAnimation, PaintAnimation},
                {AnimationEnum.UpdateAnimation, UpdateAnimation}
            };
        }

        /// <summary>
        /// Method to position the object if needed
        /// </summary>
        public void PositionObject(){
            _objectPhysics.PositionObject();
        }

        /// <summary>
        /// Animation that will be executed when object is created
        /// </summary>
        /// <returns>DOTWeen Tween with the animation</returns>
        virtual public Tween CreateAnimation()
        {
            return null;
        }

        /// <summary>
        /// Animation that will be executed when object is deleted
        /// </summary>
        /// <returns>DOTWeen Tween with the animation</returns>
        virtual public Tween DeleteAnimation()
        {
            return null;
        }

        /// <summary>
        /// Animation that paint the object with other color
        /// </summary>
        /// <returns>DOTWeen Tween with the animation</returns>
        virtual public Tween PaintAnimation()
        {
            return null;
        }

        /// <summary>
        /// Animation that keep paint the object
        /// </summary>
        /// <returns>DOTWeen Tween with the animation</returns>
        virtual public Tween KeepPaintAnimation()
        {
            return null;
        }

        /// <summary>
        /// Animation that restore the original object color
        /// </summary>
        /// <returns>DOTWeen Tween with the animation</returns>
        virtual public Tween UnPaintAnimation()
        {
            return null;
        }

        /// <summary>
        /// Animation that actualice the object visual elements
        /// </summary>
        /// <returns>DOTWeen Tween with the animation</returns>
        virtual public Tween UpdateAnimation()
        {
            return default;
        }

        /// <summary>
        /// Method to move the object of the given coordinates
        /// </summary>
        /// <param name="coordinates">Coordinates to move the object</param>
        virtual public void Move(Vector3 coordinates)
        {
        }

        virtual public void SetDTO(ElementDTO dto)
        {
            if(Dto != null){
                Dto.UpdateProperties(dto);
            }
            else{
                Dto = dto;
            }
            if(text != null){
                if(dto.Value != null){
                    text.text = dto.Value.ToString();
                }
            }
        }

        public override bool Equals(object other)
        {
            return Equals(other as ProjectedObject);
        }

        public bool Equals(ProjectedObject other)
        {
            return other != null &&
                Dto.Id == other.Dto.Id;
        }

        public override int GetHashCode()
        {
            //TODO: Look how to implement this method since library HashCode.Combine can't be used
            throw new NotImplementedException();
        }

        public bool IsSelectable()
        {
            return _selectable;
        }

        /// <summary>
        /// Method to define if the object can be selected or no
        /// </summary>
        /// <param name="selectable">True if the object can be selected, false otherwise</param>
        public void SetSelectable(bool selectable)
        {
            this._selectable = selectable;
        }
        public bool IsSelected()
        {
            return _selected;
        }

        /// <summary>
        /// Method to change the color if the object is selected
        /// </summary>
        /// <param name="selected">True if the object was selected, false otherwise</param>
        public void SetSelected(bool selected)
        {
            this._selected = selected;
            MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            if (_selected)
            {
                mesh.material.DOColor(Constants.SelectionColor, 0);
            }
            else
            {
                mesh.material.DOColor(Constants.BaseObjectColor, 0);
            }
        }
    }
}