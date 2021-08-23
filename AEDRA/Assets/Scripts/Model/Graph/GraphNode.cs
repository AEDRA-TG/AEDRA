using System;
using SideCar;
using Utils.Enums;

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

        public GraphNode(int id, object value){
            Value = value;
            Id = id;
        }
    }
}