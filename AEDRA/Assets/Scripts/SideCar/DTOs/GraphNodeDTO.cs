using System.Collections.Generic;
using UnityEngine;

namespace SideCar.DTOs
{
    /// <summary>
    /// Class that contains a Grap Node information
    /// </summary>
    public class GraphNodeDTO : ElementDTO
    {
        /// <summary>
        /// List of the node neighbors
        /// </summary>
        public List<int> Neighbors {get; set;}

        /// <summary>
        /// Element to be connected to the new element
        /// </summary>
        public int? ElementToConnectID {get; set;}

        public GraphNodeDTO(int idNode, object value, List<int> neighbors):base(idNode, value){
            Neighbors = neighbors;
            base.Name = "Node";
        }

        public override void UpdateProperties(ElementDTO DTO)
        {
            GraphNodeDTO updatedDTO = (GraphNodeDTO) DTO;
            this.Neighbors = updatedDTO.Neighbors;
            this.ElementToConnectID = updatedDTO.ElementToConnectID;
            base.Coordinates = new Point(updatedDTO.Coordinates.X, updatedDTO.Coordinates.Y, updatedDTO.Coordinates.Z);
            if(DTO.Info != default){
                base.Info = updatedDTO.Info;
            }
            base.Operation = DTO.Operation;
        }
    }
}