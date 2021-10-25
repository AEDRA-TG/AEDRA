using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace SideCar.DTOs
{
    /// <summary>
    /// Class that define the basic information for all dtos
    /// </summary>
    public class ElementDTO
    {
        /// <summary>
        /// Element id
        /// </summary>
        public int Id {get; set;}

        //Todo define passing generic values
        /// <summary>
        /// Element value
        /// </summary>
        /// <value></value>
        public object Value {get; set;}

        /// <summary>
        /// Name used to identify the element on view
        /// </summary>
        /// <value></value>
        public string Name {get; set;}

        /// <summary>
        /// Element coordinates on view
        /// </summary>
        /// <value></value>
        public Point Coordinates {get; set;}

        /// <summary>
        /// Operation applied to the element
        /// </summary>
        public AnimationEnum Operation {get; set;}

        public Color Color {get; set;}

        public string Info {get;  set;}

        public string Step {get; set;}


        public ElementDTO(int id, object value){
            Id = id;
            Value = value;
            Info = default;
        }

        /// <summary>
        /// Method to create and returns the view id of the element
        /// </summary>
        /// <returns>View id of the element</returns>
        public virtual string GetUnityId(){
            return Name + "_" + Id;
        }

        public virtual void UpdateProperties(ElementDTO DTO){
        }
    }
}