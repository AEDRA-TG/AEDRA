using System.Collections.Generic;
using System.Collections;
using System;

namespace Model.Graph
{
    /// <summary>
    /// Class to manage operations and data realted to a Graph
    /// </summary>
    public class Graph : IDataStructure
    {
        /// <summary>
        /// Event for notify Add Node operation
        /// </summary>
        public static event Action<object> OnAddNodeEvent;

        /// <summary>
        /// List to store nodes of the graph
        /// </summary>
        public List<GraphNode> Nodes {get; set;}

        /// <summary>
        /// Adjacent matrix of the graph
        /// </summary>
        public Dictionary<int, Dictionary<int, Object>> AdjacentMtx { get; set; }

        /// <summary>
        /// Method to add a node on the graph
        /// </summary>
        /// <param name="element"> Node that will be added to the graph </param>
        public void AddElement(object element)
        {
            // Notify to subscribers 
            OnAddNodeEvent?.Invoke(element);
        }

        /// <summary>
        /// Method to remove a node of the graph
        /// </summary>
        /// <param name="element"> Node that will be removed</param>
        public void DeleteElement(object element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to do a traversal on the graph
        /// </summary>
        /// <param name="traversalName"> Name of the traversal to execute</param>
        public void DoTraversal(string traversalName)
        {
            throw new NotImplementedException();
        }
    }
}