namespace Model.TreeModel.BinaryTree.Traversals
{
    public interface ITraversalTreeStrategy
    {
        /// <summary>
        /// Method to perform the corresponding traversal strategy
        /// </summary>
        /// <param name="tree">Tree where the traversal will be executed</param>
        public void DoTraversal(BinarySearchTree tree);
    }
}