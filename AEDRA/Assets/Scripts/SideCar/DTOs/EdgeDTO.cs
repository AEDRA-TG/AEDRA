
namespace SideCar.DTOs
{
    public class EdgeDTO : ElementDTO
    {
        public int IdStartNode {set; get;}
        public int IdEndNode {set; get;}
        public EdgeDTO(int idEdge, object value, int idStartNode, int idEndNode):base(idEdge, value){
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