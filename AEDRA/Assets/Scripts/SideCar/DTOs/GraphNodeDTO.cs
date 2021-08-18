using System.Collections.Generic;
using Utils.Enums;

namespace Model.SideCar.DTOs
{
    public class GraphNodeDTO : DataStructureElementDTO
    {
        public List<int> Neighbors {get; set;}

        public GraphNodeDTO(int idNode, object value, List<int> neighbors):base(idNode, value){
            Neighbors = neighbors;
        }
    }
}