using SideCar.DTOs;
namespace Model.GraphModel
{
    /// <summary>
    /// Class to manage any node of a graph
    /// </summary>
    public class GraphNode
    {
        public int Id { get; set; }
        //TODO: define how to have generic values
        public object Value { get; set; }
        /// <summary>
        /// Node coordinates on view
        /// </summary>
        public Point Coordinates { get; set; }
        public GraphNode(int id, object value, Point coordinates){
            Value = value;
            Id = id;
            Coordinates = coordinates ?? new Point(0, 0, 0);
        }
    }
}