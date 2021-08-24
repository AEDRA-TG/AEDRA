using Model.Common;
using Model.GraphModel;
using Utils;

namespace Repository
{
    public class GraphRepository : IDataStructureRepository
    {
        private static Graph graph;
        private string _filePath;
        public GraphRepository(string structureName){
            this._filePath = Constants.DataStructureFilePath + structureName + ".json";
        }
        private Graph GetInstance()
        {
            if (graph == null)
            {
                graph = Utilities.DeserializeJSON<Graph>(_filePath);
                graph ??= new Graph();
            }
            return graph;
        }
        public DataStructure Load()
        {
            return GetInstance();
        }

        public void Save()
        {
            Utilities.SerializeJSON<Graph>(_filePath,graph);
        }
    }
}