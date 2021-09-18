
namespace SideCar.DTOs
{
    public class BinarySearchNodeDTO : ElementDTO
    {
        public int? ParentId{get;set;}
        public bool IsLeft{get;set;}
        public int? LeftChild{get;set;}
        public int? RightChild{get;set;}
        public BinarySearchNodeDTO(int id, object value, int? parentId, bool isLeft, int? leftChild, int? rigthtChild) : base(id, value)
        {
            this.ParentId = parentId;
            this.IsLeft = isLeft;
            this.LeftChild = leftChild;
            this.RightChild = rigthtChild;
            base.Name = "Node";
        }
    }
}