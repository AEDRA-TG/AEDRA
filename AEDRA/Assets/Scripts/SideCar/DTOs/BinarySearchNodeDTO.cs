
namespace SideCar.DTOs
{
    /// <summary>
    /// Class that containts an Binary Search Node information
    /// </summary>
    public class BinarySearchNodeDTO : ElementDTO
    {
        /// <summary>
        /// Parent id of the node
        /// </summary>
        /// <value>Null if the node is the tree root</value>
        public int? ParentId{get;set;}

        /// <summary>
        /// If node is a left child
        /// </summary>
        /// <value>True if node is a left child, false otherwise</value>
        public bool IsLeft{get;set;}

        /// <summary>
        /// Id node of the left child node
        /// </summary>
        /// <value>Null if node dont have left child</value>
        public int? LeftChild{get;set;}

        /// <summary>
        /// Id node of the right child node
        /// </summary>
        /// <value>Null if node dont have right child</value>
        public int? RightChild{get;set;}

        public BinarySearchNodeDTO(int id, object value, int? parentId, bool isLeft, int? leftChild, int? rigthtChild) : base(id, value)
        {
            this.ParentId = parentId;
            this.IsLeft = isLeft;
            this.LeftChild = leftChild;
            this.RightChild = rigthtChild;
            base.Name = "Node";
        }

        public override void UpdateProperties(ElementDTO DTO)
        {
            BinarySearchNodeDTO newProperties = (BinarySearchNodeDTO) DTO;
            this.LeftChild = newProperties.LeftChild;
            this.RightChild = newProperties.RightChild;
            if(newProperties.Value != default){
                this.Value = newProperties.Value;
            }
        }
    }
}