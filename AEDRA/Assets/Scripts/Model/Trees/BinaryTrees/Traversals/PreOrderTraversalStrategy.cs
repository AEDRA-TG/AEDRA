using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals
{
    public class PreOrderTraversalStrategy : ITraversalTreeStrategy
    {
        public void DoTraversal(BinarySearchTree tree)
        {
            if(tree.GetRoot() != null){
                PreOrder(tree.GetRoot(), null);
            }
        }

        public void PreOrder(BinarySearchTreeNode node, BinarySearchTreeNode parent)
        {
            if(node==null)
            {
                return;
            }
            if(parent!=null)
            {
                node.NotifyEdge(parent, node, AnimationEnum.PaintAnimation);
            }
            node.NotifyNode(parent, node, AnimationEnum.PaintAnimation);
            PreOrder(node._leftChild, node);
            PreOrder(node._rightChild, node);

        }
    }
}