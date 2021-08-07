using System.Collections.Generic;
using System.Collections;
using System;

namespace Model.Graph
{
    public class Graph
    {
        public static event Action OnAddNodeEvent;
        public List<GraphNode> Nodes {get; set;}
        public Dictionary<int, Dictionary<int, Object>> AdjacentMtx { get; set; }

        public void AddNode(){
            OnAddNodeEvent?.Invoke();
        }
    }
}