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

        public override string GetUnityId(){
            if (IdStartNode < IdEndNode)
            {
                return base.Name + "_" + IdStartNode + "_" + IdEndNode;
            }
            else
            {
                return base.Name + "_" + IdEndNode + "_" + IdStartNode;
            }
        }
    }
}