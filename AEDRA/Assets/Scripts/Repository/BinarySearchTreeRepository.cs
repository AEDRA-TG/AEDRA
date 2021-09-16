using Model.Common;
using Model.TreeModel;
using Utils;
using Utils.Enums;

namespace Repository
{
    public class BinarySearchTreeRepository: DataStructureRepository
    {
        private static BinarySearchTree tree;
        private string _filePath;
        public BinarySearchTreeRepository(StructureEnum structureName){
            this._filePath = Constants.DataPath + structureName.ToString() + ".json";
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
        public override DataStructure Load()
        {
            return GetInstance();
        }

        public override void Save()
        {
            Utilities.SerializeJSON<BinarySearchTree>(_filePath,tree);
        }

        public override void Clean(){
            if(Utilities.DeleteFile(_filePath)){
                tree = new BinarySearchTree();
                base.Notify();
            }
        }
    }
}