using Model.Common;
using Model.GraphModel;
using Utils;
using Utils.Enums;

namespace Repository
{
    public class GraphRepository : DataStructureRepository
    {
        private static Graph graph;
        private string _filePath;
        public GraphRepository(StructureEnum structureName){
            this._filePath = Constants.DataPath + structureName.ToString() + ".json";
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
        public override DataStructure Load()
        {
            return GetInstance();
        }

        public override void Save()
        {
            Utilities.SerializeJSON<Graph>(_filePath,graph);
        }

        public override void Clean(){
            if(Utilities.DeleteFile(_filePath)){
                graph = new Graph();
                base.Notify();
            }
        }
    }
}