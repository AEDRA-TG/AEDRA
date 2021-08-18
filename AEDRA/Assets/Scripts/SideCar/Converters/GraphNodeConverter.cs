
using System.Collections.Generic;
using Model.GraphModel;
using Model.SideCar.DTOs;
using Repository;

namespace Model.SideCar.Converters
{
    public class GraphNodeConverter : AbstractConverter<GraphNode, GraphNodeDTO>
    {
        public override GraphNode ToEntity(GraphNodeDTO dto)
        {
            GraphNode entity = new GraphNode(dto.Id, dto.Value);
            return entity;
        }

        public override GraphNodeDTO ToDto(GraphNode entity)
        {
            Graph graph = new GraphRepository().Load();
            List<int> neighborsIds = graph.GetNeighbors(entity.Id);
            GraphNodeDTO dto = new GraphNodeDTO(entity.Id, entity.Value,neighborsIds);
            return dto;
        }
    }
}