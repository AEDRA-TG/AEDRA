using Model.GraphModel;
using Utils;

namespace Repository
{
    public class GraphRepository : IDataStructureRepository<Graph>
    {
        private static Graph graph;

        private Graph GetInstance()
        {
            if (graph == null)
            {
                graph = Utilities.DeserializeJSON<Graph>(Constants.GraphFile);
                graph ??= new Graph();
            }
            return graph;
        }
        public Graph Load()
        {
            return GetInstance();
        }

        public void Save(Graph data)
        {
            Utilities.SerializeJSON<Graph>(Constants.GraphFile,data);
        }
    }
}