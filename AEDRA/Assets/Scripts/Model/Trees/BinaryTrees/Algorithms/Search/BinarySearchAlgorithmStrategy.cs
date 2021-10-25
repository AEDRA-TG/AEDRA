using SideCar.DTOs;
using Utils.Enums;

namespace Model.TreeModel.BinaryTree.Algorithms.Search
{
    /// <summary>
    /// Class to perform Tree Binary Search Algorithm on a Tree
    /// </summary>
    public class BinarySearchAlgorithmStrategy : IBinaryTreeSearchStrategy
    {
        public void DoAlgorithm(BinarySearchTree tree, ElementDTO data = null)
        {
            if(tree.GetRoot() != null){
                BinarySearch((int)data.Value,tree.GetRoot(), null);
            }
        }

        /// <summary>
        /// Method to make the search recursively
        /// </summary>
        /// <param name="value">Value to search on the tree</param>
        /// <param name="node">Actual node of the recursion</param>
        /// <param name="parent">Parent of the actual node</param>
        private void BinarySearch(int value,BinarySearchTreeNode node, BinarySearchTreeNode parent){
            if(node == null){
                return;
            }
            if(parent != null){
                node.NotifyEdge(parent, node, AnimationEnum.KeepPaintAnimation);
            }
            if(value < node.Value){
                node.NotifyNode(parent, node, AnimationEnum.KeepPaintAnimation);
                BinarySearch(value, node.LeftChild, node);
            }
            else if(value > node.Value){
                node.NotifyNode(parent, node, AnimationEnum.KeepPaintAnimation);
                BinarySearch(value, node.RightChild, node);
            }
            else{
                node.NotifyNode(parent, node, AnimationEnum.PaintValueFoundAnimation);
                return;
            }
        }
    }
}