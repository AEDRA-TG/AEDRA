using System.Collections.Generic;
using System.Collections;
using System;

namespace Model.Graph
{
    public class Graph : IDataStructure
    {
        public static event Action<object> OnAddNodeEvent;
        public List<GraphNode> Nodes {get; set;}
        public Dictionary<int, Dictionary<int, Object>> AdjacentMtx { get; set; }

        public void AddElement(object element)
        {
            OnAddNodeEvent?.Invoke(element);
        }

        public void DeleteElement(object element)
        {
            throw new NotImplementedException();
        }

        public void DoTraversal(string traversalName)
        {
            throw new NotImplementedException();
        }
    }
}