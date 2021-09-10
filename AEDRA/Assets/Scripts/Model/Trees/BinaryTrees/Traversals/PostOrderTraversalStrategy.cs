using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals
{
    public class PostOrderTraversalStrategy : ITraversalTreeStrategy
    {
        public void DoTraversal(BinarySearchTree tree)
        {
            if(tree.GetRoot() != null){
                PostOrder(tree.GetRoot(), null);
            }
        }

        public void PostOrder(BinarySearchTreeNode node, BinarySearchTreeNode parent)
        {
            if(node==null)
            {
                return;
            }
            if(parent!=null)
            {
                node.NotifyEdge(parent, node, AnimationEnum.KeepPaintAnimation);
            }
            PostOrder(node.LeftChild, node);
            PostOrder(node.RightChild, node);
            node.NotifyNode(parent, node, AnimationEnum.KeepPaintAnimation);
            if(parent!=null)
            {
                node.NotifyEdge(parent, node, AnimationEnum.UnPaintAnimation);
            }
        }
    }
}