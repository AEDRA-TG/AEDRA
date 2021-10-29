using System;
using System.Collections.Generic;
using System.Linq;
using SideCar.DTOs;
using C5;
using Utils.Enums;
using UnityEngine;
using Utils;

namespace Model.GraphModel.Algorithms.ShortestPath
{
    public class DijkstraShortestPath : IShortestPathStrategy
    {
        public void FindShortestPath(Graph graph, ElementDTO startNode, ElementDTO endNode)
        {
            Dictionary<int, bool> visitedMap = graph.Nodes.Keys.ToDictionary(id => id, _ => false);
            IntervalHeap<Tuple<double, int, int>> heap = new IntervalHeap<Tuple<double, int, int>>
            {
                new Tuple<double, int, int>(0,startNode.Id, startNode.Id)
            };
            while (heap.Count > 0){
                Tuple<double,int, int> nodes = heap.DeleteMin();
                double cost = nodes.Item1;
                int previous = nodes.Item2;
                int current = nodes.Item3;
                graph.NotifyNode(current, AnimationEnum.StepInformationAppendAnimation, "", 3);
                graph.NotifyNode(current, AnimationEnum.StepInformationAppendAnimation, "", 4);
                if(!visitedMap[current]){
                    graph.NotifyNode(current, AnimationEnum.StepInformationAppendAnimation, "", 5);
                    visitedMap[current] = true;
                    if(graph.AdjacentMtx[previous].ContainsKey(current)){
                        graph.NotifyEdge(previous,current,AnimationEnum.KeepPaintAnimation);
                    }
                    graph.NotifyNode(current,AnimationEnum.KeepPaintAnimation);
                    graph.NotifyNode(current,AnimationEnum.UpdateAnimation, "C = "+ cost);
                    graph.NotifyNode(current,AnimationEnum.StepInformationJoinAnimation, "C = "+ cost, 1 );
                    foreach (int key in graph.AdjacentMtx[current].Keys)
                    {
                        GraphNode neighboorNode = graph.Nodes[key];
                        if(!visitedMap[neighboorNode.Id]){
                            double noVisitedCost = (double)graph.AdjacentMtx[current][neighboorNode.Id];
                            graph.NotifyNode(neighboorNode.Id, AnimationEnum.StepInformationAppendAnimation, "", 2);
                            graph.NotifyNode(neighboorNode.Id, AnimationEnum.UpdateAnimation, "C = " + cost + " + " + noVisitedCost);
                            heap.Add(new Tuple<double, int, int>(cost + noVisitedCost, current, neighboorNode.Id));
                        }
                    }
                }
                else{
                    graph.NotifyNode(current, AnimationEnum.StepInformationAppendAnimation, "", 6);
                }
            }
        }
    }
}