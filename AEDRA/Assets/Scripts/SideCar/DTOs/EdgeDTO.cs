
namespace SideCar.DTOs
{
    /// <summary>
    /// Class that containts an edge information
    /// </summary>
    public class EdgeDTO : ElementDTO
    {
        /// <summary>
        /// Id of the start node
        /// </summary>
        public int IdStartNode {set; get;}

        /// <summary>
        /// Id of the end node
        /// </summary>
        /// <value></value>
        public int IdEndNode {set; get;}

        public EdgeDTO(int idEdge, object value, int idStartNode, int idEndNode):base(idEdge, value){
            this.IdEndNode = idEndNode;
            this.IdStartNode = idStartNode;
            base.Name = "Edge";
        }

        /// <summary>
        /// Method to create and returns the view id of the element
        /// </summary>
        /// <returns>View id of the element</returns>
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