using System.Collections.Generic;
using Utils.Enums;

namespace SideCar.DTOs
{
    public class GraphNodeDTO : ElementDTO
    {
        public List<int> Neighbors {get; set;}

        public GraphNodeDTO(int idNode, object value, List<int> neighbors):base(idNode, value){
            Neighbors = neighbors;
            base.Name = "Node";
        }
    }
}