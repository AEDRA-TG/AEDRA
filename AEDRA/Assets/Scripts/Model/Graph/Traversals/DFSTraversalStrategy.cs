using System.Collections.Generic;
using System.Linq;
using SideCar.DTOs;
using Utils;
using Utils.Enums;

namespace Model.GraphModel.Traversals
{
    /// <summary>
    /// Class to perform Depth First Search Traversal on a Graph
    /// </summary>
    public class DFSTraversalStrategy : ITraversalGraphStrategy
    {
        /// <summary>
        /// Graph to apply the traversal
        /// </summary>
        private static Graph graph;

        /// <summary>
        /// Dictionary that indicates if a node was visited
        /// </summary>
        private static Dictionary<int,bool> visited;
        public void DoTraversal(Graph graph, ElementDTO data = null)
        {
            DFSTraversalStrategy.graph = graph;
            visited = graph.Nodes.Keys.ToDictionary(id => id, _ => false);
            DFS(data.Id);
        }

        /// <summary>
        /// Method to traverse the graph recursively
        /// </summary>
        /// <param name="currentNode">Current node that is being visited</param>
        public void DFS(int currentNode){
            visited[currentNode] = true;
            graph.NotifyNode(currentNode, AnimationEnum.KeepPaintAnimation);
            //Traverse all neighbors of a node
            foreach (int neighboor in DFSTraversalStrategy.graph.AdjacentMtx[currentNode].Keys)
            {
                if(!visited[neighboor]){
                    graph.NotifyEdge(currentNode, neighboor, AnimationEnum.KeepPaintAnimation);
                    DFS(neighboor);
                }
            }
        }
    }
}