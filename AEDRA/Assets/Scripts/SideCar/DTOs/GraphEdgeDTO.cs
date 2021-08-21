using System.Collections.Generic;
using Utils.Enums;

namespace SideCar.DTOs
{
    public class GraphEdgeDTO : DataStructureElementDTO
    {
        public int IdEndNode {set; get;}
        public GraphEdgeDTO(int idNode, object value, int idEndNode):base(idNode, value){
            this.IdEndNode = idEndNode;
        }
    }
}