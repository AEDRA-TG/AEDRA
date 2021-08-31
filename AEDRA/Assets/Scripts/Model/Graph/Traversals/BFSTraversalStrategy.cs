using System;
using System.Collections.Generic;
using SideCar.DTOs;
using Utils.Enums;

namespace Model.GraphModel.Traversals
{
    public class BFSTraversalStrategy : ITraversalGraphStrategy
    {
        public void DoTraversal(Graph graph, ElementDTO startNode = null)
        {
            Dictionary<int, bool> visitedMap = InitializeVisiteMap(new List<int>(graph.Nodes.Keys));
            // Item1 anterior item2 actual
            Queue<Tuple<int, int> > q = new Queue<Tuple<int, int> >();
            q.Enqueue(new Tuple<int, int>(startNode.Id, startNode.Id));

            while(q.Count > 0){
                Tuple<int, int> nodes = q.Dequeue();
                int previous = nodes.Item1;
                int current = nodes.Item2;

                visitedMap[current] = true;
                if(graph.AdjacentMtx[previous].ContainsKey(current)){
                    graph.NotifyEdge(previous,current,AnimationEnum.PaintAnimation);
                }
                graph.NotifyNode(current,AnimationEnum.PaintAnimation);

                foreach (int key in graph.AdjacentMtx[current].Keys)
                {
                    GraphNode neighboorNode = graph.Nodes[key];
                    if(!visitedMap[neighboorNode.Id]){
                        q.Enqueue(new Tuple<int, int>(current, neighboorNode.Id));
                    }
                }
            }
        }

        /// <summary>
        /// Method to initialize the visited map for traversals
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, bool> InitializeVisiteMap(List<int> nodes){
            Dictionary<int, bool> visitedMap = new Dictionary<int, bool>();
            foreach (int id in nodes)
            {
                visitedMap.Add(id, false);
            }
            return visitedMap;
        }
    }
}