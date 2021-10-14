using System.Collections.Generic;
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

        public override ElementDTO UpdateProperties(ElementDTO DTO)
        {
            GraphNodeDTO converted = (GraphNodeDTO) DTO;
            this.Neighbors = converted.Neighbors;
            this.ElementToConnectID = converted.ElementToConnectID;
            base.Coordinates = converted.Coordinates;
            if(DTO.Info != default){
                base.Info = converted.Info;
            }
            if(DTO.Color != default){
                base.Color = converted.Color;
            }
            return this;
        }
    }
}