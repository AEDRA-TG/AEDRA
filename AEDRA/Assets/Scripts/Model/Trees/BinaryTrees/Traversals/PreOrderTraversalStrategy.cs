using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals
{
    public class PreOrderTraversalStrategy : ITraversalTreeStrategy
    {
        public void DoTraversal(BinarySearchTree tree)
        {
            if(tree.GetRoot() != null){
                tree.GetRoot().NotifyNode(null, tree.GetRoot(), AnimationEnum.PaintAnimation);
                PreOrder(tree.GetRoot());
            }
        }

        public void PreOrder(BinarySearchTreeNode node)
        {
            if ( node._leftChild != null ){
                node.NotifyEdge(node, node._leftChild, AnimationEnum.PaintAnimation);
                node.NotifyNode(node, node._leftChild, AnimationEnum.PaintAnimation);
                PreOrder(node._leftChild);
            }
            if ( node._rightChild != null ){
                node.NotifyEdge(node, node._rightChild, AnimationEnum.PaintAnimation);
                node.NotifyNode(node, node._rightChild, AnimationEnum.PaintAnimation);
                PreOrder(node._rightChild);
            }
        }
    }
}