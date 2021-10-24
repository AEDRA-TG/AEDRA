using Repository;
using Utils.Enums;

namespace Controller
{
    /// <summary>
    /// Class to manage load data structure information
    /// </summary>
    public class LoadCommand : Command
    {
        /// <summary>
        /// Data structure name that will loaded
        /// </summary>
        private StructureEnum _structureName;
        private string _dataFile;

        /// <summary>
        /// Command to load a DataStructure from persistent storage
        /// </summary>
        /// <param name="structureName"> Name of the data structure to load</param>
        public LoadCommand(StructureEnum structureName, string dataFile)
        {
            this._structureName = structureName;
            this._dataFile = dataFile;
        }

        public override void Execute()
        {
            DataStructureRepository repository =  RepositoryFactory.CreateRepository(_structureName, _dataFile);
            CommandController.GetInstance().Repository = repository;
            repository.Load().CreateDataStructure();
            Notify(OperationEnum.CreateDataStructure);
        }
    }
}