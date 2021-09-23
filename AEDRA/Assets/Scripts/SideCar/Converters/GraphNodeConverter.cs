
using System.Collections.Generic;
using Model.GraphModel;
using SideCar.DTOs;
using Controller;

namespace SideCar.Converters
{
    /// <summary>
    /// Class to manage the graph node converter
    /// </summary>
    public class GraphNodeConverter : AbstractConverter<GraphNode, GraphNodeDTO>
    {
        /// <summary>
        /// Method to convert GraphNodeDTO to GraphNode
        /// </summary>
        /// <param name="dto">Dto to convert</param>
        /// <returns>GrapNode with the dto information</returns>
        public override GraphNode ToEntity(GraphNodeDTO dto)
        {
            GraphNode entity = new GraphNode(dto.Id, dto.Value, dto.Coordinates);
            return entity;
        }

        /// <summary>
        /// Method to convert GraphNode to GraphNodeDTO
        /// </summary>
        /// <param name="entity">GraphNode to convert</param>
        /// <returns>GraphNodeDTO with the GraphNode information</returns>
        public override GraphNodeDTO ToDto(GraphNode entity)
        {
            Graph graph = (Graph)CommandController.GetInstance().Repository.Load();
            List<int> neighborsIds = graph.GetNeighbors(entity.Id);
            GraphNodeDTO dto = new GraphNodeDTO(entity.Id, entity.Value, neighborsIds)
            {
                Coordinates = entity.Coordinates
            };
            return dto;
        }
    }
}