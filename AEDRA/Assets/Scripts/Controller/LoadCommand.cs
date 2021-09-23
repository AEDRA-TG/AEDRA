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

        /// <summary>
        /// Command to load a DataStructure from persistent storage
        /// </summary>
        /// <param name="structureName"> Name of the data structure to load</param>
        public LoadCommand(StructureEnum structureName)
        {
            this._structureName = structureName;
        }

        public override void Execute()
        {
            DataStructureRepository repository =  RepositoryFactory.CreateRepository(_structureName);
            CommandController.GetInstance().Repository = repository;
            repository.Load().CreateDataStructure();
            Notify(OperationEnum.CreateDataStructure);
        }
    }
}