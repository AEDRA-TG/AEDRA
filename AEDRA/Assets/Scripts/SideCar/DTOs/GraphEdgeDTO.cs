using System.Collections.Generic;
using Utils.Enums;

namespace SideCar.DTOs
{
    public class GraphEdgeDTO : ElementDTO
    {
        public int IdStartNode {set; get;}
        public int IdEndNode {set; get;}
        public GraphEdgeDTO(int idEdge, object value, int idStartNode, int idEndNode):base(idEdge, value){
            this.IdEndNode = idEndNode;
            this.IdStartNode = idStartNode;
            base.Name = "Edge";
        }
    }
}