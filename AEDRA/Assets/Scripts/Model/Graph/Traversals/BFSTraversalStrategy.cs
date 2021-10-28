using System;
using System.Collections.Generic;
using System.Linq;
using SideCar.DTOs;
using UnityEngine;
using Utils;
using Utils.Enums;

namespace Model.GraphModel.Traversals
{
    /// <summary>
    /// Class to perform Breath First Search Traversal on a Graph
    /// </summary>
    public class BFSTraversalStrategy : ITraversalGraphStrategy
    {
        public void DoTraversal(Graph graph, ElementDTO startNode = null)
        {
            Dictionary<int, bool> visitedMap = graph.Nodes.Keys.ToDictionary(id => id, _ => false);
            // Item1 Previous neighbour node item2 actual node
            Queue<Tuple<int, int> > q = new Queue<Tuple<int, int> >();
            q.Enqueue(new Tuple<int, int>(startNode.Id, startNode.Id));

            while(q.Count > 0){
                Tuple<int, int> nodes = q.Dequeue();
                int previous = nodes.Item1;
                int current = nodes.Item2;
                if(!visitedMap[current]){
                    visitedMap[current] = true;
                    if(graph.AdjacentMtx[previous].ContainsKey(current)){
                        graph.NotifyEdge(previous,current,AnimationEnum.KeepPaintAnimation);
                    }
                    graph.NotifyNode(current,AnimationEnum.StepInformationJoinAnimation,"", 1 );
                    graph.NotifyNode(current,AnimationEnum.KeepPaintAnimation);

                    foreach (int key in graph.AdjacentMtx[current].Keys)
                    {
                        GraphNode neighboorNode = graph.Nodes[key];
                        if(!visitedMap[neighboorNode.Id]){
                            q.Enqueue(new Tuple<int, int>(current, neighboorNode.Id));
                        }
                    }
                }
            }
        }
    }
}