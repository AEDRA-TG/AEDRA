
using System.Collections.Generic;
using Model.GraphModel;
using SideCar.DTOs;
using Repository;
using Controller;

namespace SideCar.Converters
{
    public class GraphNodeConverter : AbstractConverter<GraphNode, GraphNodeDTO>
    {
        public override GraphNode ToEntity(GraphNodeDTO dto)
        {
            GraphNode entity = new GraphNode(dto.Id, dto.Value, dto.Coordinates);
            return entity;
        }

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