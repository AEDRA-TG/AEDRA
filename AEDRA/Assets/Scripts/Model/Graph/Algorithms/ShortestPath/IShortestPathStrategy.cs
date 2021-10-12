using SideCar.DTOs;

namespace Model.GraphModel.Algorithms.ShortestPath
{
    public interface IShortestPathStrategy
    {
        void FindShortestPath(Graph graph, ElementDTO startNode, ElementDTO endNode);
    }
}