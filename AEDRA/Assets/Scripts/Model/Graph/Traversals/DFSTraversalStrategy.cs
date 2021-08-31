using System.Collections.Generic;
using SideCar.DTOs;

namespace Model.GraphModel.Traversals
{
    public class DFSTraversalStrategy : ITraversalGraphStrategy
    {
        private static Graph graph;
        private static Dictionary<int,bool> visted;
        
        public void DoTraversal(Graph graph, ElementDTO data = null)
        {

        }

        public void DFS(int nodeId){
            /*
            graph.NotifyNode(current)
            foreach (int node in neighboors)
            {
                if(!visited[neighboor]){
                    graph.NotifyEdge(current, neighboor)
                    DFS(graph, neighboor, visited)    
                }
            }
            */
        }
    }
}