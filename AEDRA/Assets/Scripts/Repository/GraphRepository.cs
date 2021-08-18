using Model.GraphModel;

namespace Repository
{
    public class GraphRepository : IDataStructureRepository<Graph>
    {
        private static Graph graph;

        private Graph GetInstance()
        {
            if (graph == null)
            {
                graph = new Graph();
            }
            return graph;
        }
        public Graph Load()
        {
            return GetInstance();
        }

        public void Save(Graph data)
        {
            graph = data;
        }
    }
}