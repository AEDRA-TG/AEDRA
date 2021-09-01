using SideCar.DTOs;

namespace Model.GraphModel.Traversals
{
    public interface ITraversalGraphStrategy
    {
        /// <summary>
        /// Method to perform the corresponding traversal strategy
        /// </summary>
        /// <param name="graph">Graph where the traversal will be executed</param>
        /// <param name="data">Optional parameter that has the required data for the traversal</param>
        public void DoTraversal(Graph graph, ElementDTO data = null);
    }
}