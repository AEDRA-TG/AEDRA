using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals
{
    public class InOrderTraversalStrategy : ITraversalTreeStrategy
    {
        public void DoTraversal(BinarySearchTree tree)
        {
            if(tree.GetRoot() != null){
                InOrder(tree.GetRoot(), null);
            }
        }

        public void InOrder(BinarySearchTreeNode node, BinarySearchTreeNode parent)
        {
            if(node==null)
            {
                return;
            }
            if(parent!=null)
            {
                node.NotifyEdge(parent, node, AnimationEnum.KeepPaintAnimation);
            }
            InOrder(node.LeftChild, node);
            node.NotifyNode(parent, node, AnimationEnum.KeepPaintAnimation);
            InOrder(node.RightChild, node);
            if(parent!=null)
            {
                node.NotifyEdge(parent, node, AnimationEnum.UnPaintAnimation);
            } 
        }
    }
}