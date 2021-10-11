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
    }
}