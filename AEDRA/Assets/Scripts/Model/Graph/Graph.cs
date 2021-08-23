using System.Collections.Generic;
using System.Collections;
using System;
using Utils.Enums;
using Model.Common;
using SideCar.Converters;
using SideCar.DTOs;
using UnityEngine;
using Newtonsoft.Json;
using Repository;

namespace Model.GraphModel
{
    /// <summary>
    /// Class to manage operations and data realted to a Graph
    /// </summary>
    public class Graph : DataStructure
    {
        [JsonProperty]
        public static int NodesId{get; set;}
        [JsonProperty]
        public static int EdgesId{get; set;}

        /// <summary>
        /// List to store nodes of the graph
        /// </summary>
        public List<GraphNode> Nodes {get; set;}

        /// <summary>
        /// Adjacent matrix of the graph
        /// </summary>
        public Dictionary<int, Dictionary<int, object>> AdjacentMtx { get; set; }

        private GraphNodeConverter _nodeConverter;

        public Graph(){
            NodesId = 0;
            EdgesId = 0;
            Nodes = new List<GraphNode>();
            AdjacentMtx = new Dictionary<int, Dictionary<int, object>>();
            _nodeConverter = new GraphNodeConverter();
        }

        /// <summary>
        /// Method to add a node on the graph
        /// </summary>
        /// <param name="element"> Node that will be added to the graph </param>
        public override void AddElement(ElementDTO element)
        {
            //TODO: change ID generation(see also how to remove Ids without clash)
            GraphNode node = _nodeConverter.ToEntity((GraphNodeDTO)element);
            node.Id = NodesId++;
            Nodes.Add(node);
            AdjacentMtx.Add(node.Id, new Dictionary<int, object>());
            //return DTO updated
            element = _nodeConverter.ToDto(node);
            element.Operation = AnimationEnum.CreateAnimation;
            base.Notify(element);
        }

        /// <summary>
        /// Method to remove a node of the graph
        /// </summary>
        /// <param name="element"> Node that will be removed</param>
        public override void DeleteElement(ElementDTO element)
        {
            GraphNode nodeToDelete = _nodeConverter.ToEntity((GraphNodeDTO)element);
            this.Nodes.Remove(nodeToDelete);
            element.Operation = AnimationEnum.DeleteAnimation;
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

        /// <summary>
        /// Method to connect two nodes bidirectionally
        /// </summary>
        /// <param name="element"></param>
        public override void ConnectElements(ElementDTO graphEdgeDTO)
        {
            GraphEdgeDTO edgeDTO = (GraphEdgeDTO) graphEdgeDTO;
            edgeDTO.Id = EdgesId++;
            AdjacentMtx[edgeDTO.Id].Add(edgeDTO.IdEndNode, edgeDTO.Value);
            AdjacentMtx[edgeDTO.IdEndNode].Add(edgeDTO.Id, edgeDTO.Value);
            edgeDTO.Operation = AnimationEnum.CreateAnimation;
            base.Notify(edgeDTO);
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