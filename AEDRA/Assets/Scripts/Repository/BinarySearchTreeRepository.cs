using Model.Common;
using Model.TreeModel;
using Utils;
using Utils.Enums;

namespace Repository
{
    /// <summary>
    /// Class to manage binary search tree repository operations
    /// </summary>
    public class BinarySearchTreeRepository: DataStructureRepository
    {
        /// <summary>
        /// Instance of the loaded tree
        /// </summary>
        private static BinarySearchTree _tree;

        /// <summary>
        /// File path use to load and save the tree
        /// </summary>
        private string _filePath;

        public BinarySearchTreeRepository(StructureEnum structureName){
            this._filePath = Constants.DataPath + structureName.ToString() + ".json";
        }

        /// <summary>
        /// Singleton Method
        /// </summary>
        /// <returns>Unique instance of BinarySearchTreeRepository</returns>
        private BinarySearchTree GetInstance()
        {
            if (_tree == null)
            {
                _tree = Utilities.DeserializeJSON<BinarySearchTree>(_filePath);
                _tree ??= new BinarySearchTree();
            }
            return _tree;
        }

        /// <summary>
        /// Method to get the actual tree instance
        /// </summary>
        /// <returns>The actual tree instance</returns>
        public override DataStructure Load()
        {
            return GetInstance();
        }

        /// <summary>
        /// Method to save the actual tree instance
        /// </summary>
        public override void Save()
        {
            Utilities.SerializeJSON<BinarySearchTree>(_filePath,_tree);
        }

        /// <summary>
        /// Method to clean the tree file and create a new instance
        /// </summary>
        public override void Clean(){
            if(Utilities.DeleteFile(_filePath)){
                _tree = new BinarySearchTree();
                base.Notify();
            }
        }
    }
}