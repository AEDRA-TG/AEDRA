using Model.Common;
using Model.GraphModel;
using Utils;
using Utils.Enums;

namespace Repository
{
    /// <summary>
    /// Class to manage graph repository operations
    /// </summary>
    public class GraphRepository : DataStructureRepository
    {
        /// <summary>
        /// Instance of the loaded graph
        /// </summary>
        private static Graph _graph;

        /// <summary>
        /// File path use to load and save the graph
        /// </summary>
        private string _filePath;

        public GraphRepository(StructureEnum structureName){
            this._filePath = Constants.DataPath + structureName.ToString() + ".json";
        }

        /// <summary>
        /// Singleton Method
        /// </summary>
        /// <returns>Unique instance of BinarySearchTreeRepository</returns>
        private Graph GetInstance()
        {
            if (_graph == null)
            {
                _graph = Utilities.DeserializeJSON<Graph>(_filePath);
                _graph ??= new Graph();
            }
            return _graph;
        }

        /// <summary>
        /// Method to get the actual graph instance
        /// </summary>
        /// <returns>The actual graph instance</returns>
        public override DataStructure Load()
        {
            return GetInstance();
        }

        /// <summary>
        /// Method to save the actual graph instance
        /// </summary>
        public override void Save()
        {
            Utilities.SerializeJSON<Graph>(_filePath,_graph);
        }

        /// <summary>
        /// Method to clean the graph file and create a new instance
        /// </summary>
        public override void Clean(){
            if(Utilities.DeleteFile(_filePath)){
                _graph = new Graph();
                base.Notify();
            }
        }
    }
}