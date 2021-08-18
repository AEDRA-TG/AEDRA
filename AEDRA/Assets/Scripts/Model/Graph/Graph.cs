using System.Collections.Generic;
using System.Collections;
using System;
using Utils.Enums;
using Model.Common;
using SideCar.Converters;
using SideCar.DTOs;

namespace Model.GraphModel
{
    /// <summary>
    /// Class to manage operations and data realted to a Graph
    /// </summary>
    public class Graph : DataStructure
    {
        /// <summary>
        /// List to store nodes of the graph
        /// </summary>
        public List<GraphNode> Nodes {get; set;}

        /// <summary>
        /// Adjacent matrix of the graph
        /// </summary>
        public Dictionary<int, Dictionary<int, object>> AdjacentMtx { get; set; }

        public Graph(){
            Nodes = new List<GraphNode>();
            AdjacentMtx = new Dictionary<int, Dictionary<int, object>>();
        }

        /// <summary>
        /// Method to add a node on the graph
        /// </summary>
        /// <param name="element"> Node that will be added to the graph </param>
        public override void AddElement(object element)
        {
            //TODO: change ID generation(see also how to remove Ids without clash)
            int id = Nodes.Count;
            GraphNode node = new GraphNode(id, element);
            Nodes.Add(node);
            AdjacentMtx.Add(id, new Dictionary<int, object>());
            // Notify to subscribers 
            GraphNodeConverter converter = new GraphNodeConverter();
            base.Notify(converter.ToDto(node));
        }

        /// <summary>
        /// Method to remove a node of the graph
        /// </summary>
        /// <param name="element"> Node that will be removed</param>
        public override void DeleteElement(DataStructureElementDTO element)
        {
            GraphNode nodeToDelete = null;
            foreach(GraphNode node in this.Nodes){
                if(node.Id == element.Id){
                    nodeToDelete = node;
                }
            }
            this.Nodes.Remove(nodeToDelete);
            base.Notify(element);
        }

        /// <summary>
        /// Method to do a traversal on the graph
        /// </summary>
        /// <param name="traversalName"> Name of the traversal to execute</param>
        public override void DoTraversal(string traversalName)
        {
            throw new NotImplementedException();
        }

        public List<int> GetNeighbors(int node){
            List<int> neighbors = new List<int>();
            foreach (int neighbor in AdjacentMtx[node].Keys)
            {
                neighbors.Add(neighbor);
            }
            return neighbors;
        }
    }
}