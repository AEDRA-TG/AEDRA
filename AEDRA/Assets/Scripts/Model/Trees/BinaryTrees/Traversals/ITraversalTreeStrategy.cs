namespace Model.TreeModel.BinaryTree.Traversals
{
    /// <summary>
    /// Interface that defines binary search tree traversal strategy
    /// </summary>
    public interface ITraversalTreeStrategy
    {
        /// <summary>
        /// Method to perform the corresponding traversal strategy
        /// </summary>
        /// <param name="tree">Tree where the traversal will be executed</param>
        public void DoTraversal(BinarySearchTree tree);
    }
}