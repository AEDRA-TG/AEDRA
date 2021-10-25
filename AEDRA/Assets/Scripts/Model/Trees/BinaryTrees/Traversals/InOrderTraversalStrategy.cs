using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals
{
    /// <summary>
    /// Class to perform In Order traversal on a binary search tree
    /// </summary>
    public class InOrderTraversalStrategy : ITraversalTreeStrategy
    {
        public void DoTraversal(BinarySearchTree tree)
        {
            if(tree.GetRoot() != null){
                InOrder(tree.GetRoot(), null);
            }
        }

        /// <summary>
        /// Method to traverse the tree recursively
        /// </summary>
        /// <param name="node">Actual node in traversal</param>
        /// <param name="parent">Actual node parent</param>
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
        }
    }
}