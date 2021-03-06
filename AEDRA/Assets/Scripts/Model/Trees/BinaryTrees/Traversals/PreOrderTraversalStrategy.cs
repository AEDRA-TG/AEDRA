using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Traversals{
    /// <summary>
    /// Class to perform the Pre Order traversal on a Binary Search Tree
    /// </summary>
    public class PreOrderTraversalStrategy : ITraversalTreeStrategy{
        public void DoTraversal(BinarySearchTree tree){
            if(tree.GetRoot() != null){
                PreOrder(tree.GetRoot(), null);
            }
        }

        /// <summary>
        /// Method to traverse the tree recursively
        /// </summary>
        /// <param name="node">Actual node in traversal</param>
        /// <param name="parent">Actual node parent</param>
        public void PreOrder(BinarySearchTreeNode node, BinarySearchTreeNode parent){
            if(node==null){
                return;
            }
            if(parent!=null){
                node.NotifyEdge(parent, node, AnimationEnum.KeepPaintAnimation);
            }else{
                node.NotifyNode(parent, node, AnimationEnum.StepInformationJoinAnimation, 0);
            }
            node.NotifyNode(parent, node, AnimationEnum.KeepPaintAnimation);
            node.NotifyNode(node, node.LeftChild, AnimationEnum.StepInformationJoinAnimation, 1);
            PreOrder(node.LeftChild, node);
            node.NotifyNode(node, node.RightChild, AnimationEnum.StepInformationJoinAnimation, 2);
            PreOrder(node.RightChild, node);
        }
    }
}