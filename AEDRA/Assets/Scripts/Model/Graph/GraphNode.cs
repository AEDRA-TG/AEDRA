using System;
using Model.SideCar;
using Utils.Enums;

namespace Model.GraphModel
{
    /// <summary>
    /// Class to manage any node of a graph
    /// </summary>
    public class GraphNode
    {
        //TODO: Set Id automatically
        public int Id { get; set; }
        //TODO: define how to have generic values
        public object Value { get; set; }

        public GraphNode(int id, object value){
            Value = value;
            Id = id;
        }
    }
}