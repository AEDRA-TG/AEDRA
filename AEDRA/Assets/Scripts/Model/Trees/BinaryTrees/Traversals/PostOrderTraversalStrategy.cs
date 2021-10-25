using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals
{
    /// <summary>
    /// Class to perform the Post Order traversal on a Binary Search Tree
    /// </summary>
    public class PostOrderTraversalStrategy : ITraversalTreeStrategy
    {
        public void DoTraversal(BinarySearchTree tree)
        {
            if(tree.GetRoot() != null){
                PostOrder(tree.GetRoot(), null);
            }
        }

        /// <summary>
        /// Method to traverse the tree recursively
        /// </summary>
        /// <param name="node">Actual node in traversal</param>
        /// <param name="parent">Actual node parent</param>
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
        }
    }
}