using SideCar.DTOs;

namespace Model.GraphModel.Traversals
{
    public interface ITraversalGraphStrategy
    {
        public void DoTraversal(Graph graph, ElementDTO data = null);
    }
}