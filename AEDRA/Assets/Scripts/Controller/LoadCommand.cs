using System.Collections;
using System.Collections.Generic;
using Repository;
using UnityEngine;
using Utils.Enums;

namespace Controller
{
    public class LoadCommand : Command
    {
        // Start is called before the first frame update
        private StructureEnum _structureName;
        /// <summary>
        /// Command to load a DataStructure from persistent storage
        /// </summary>
        /// <param name="structureName"></param>
        public LoadCommand(StructureEnum structureName)
        {
            this._structureName = structureName;
        }

        public override void Execute()
        {
            IDataStructureRepository repository =  RepositoryFactory.CreateRepository(_structureName);
            CommandController.GetInstance().Repository = repository;
            repository.Load().CreateDataStructure();
            Notify(OperationEnum.CreateDataStructure);
        }
    }
}