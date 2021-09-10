using Model.Common;
using Model.TreeModel;
using UnityEngine;
using Utils;
using Utils.Enums;

namespace Repository
{
    public class BinarySearchTreeRepository: IDataStructureRepository
    {
        private static BinarySearchTree tree;
        private string _filePath;
        public BinarySearchTreeRepository(StructureEnum structureName){
            this._filePath = Constants.DataStructureFilePath + structureName.ToString() + ".json";
        }
        private BinarySearchTree GetInstance()
        {
            if (tree == null)
            {
                tree = Utilities.DeserializeJSON<BinarySearchTree>(_filePath);
                tree ??= new BinarySearchTree();
            }
            return tree;
        }
        public DataStructure Load()
        {
            return GetInstance();
        }

        public void Save()
        {
            Utilities.SerializeJSON<BinarySearchTree>(_filePath,tree);
        }
    }
}