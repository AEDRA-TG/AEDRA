using SideCar.DTOs;

namespace Model.TreeModel.BinaryTree.Algorithms.Search
{
    /// <summary>
    /// Interface that defines tree algorithm strategy
    /// </summary>
    public interface IBinaryTreeSearchStrategy
    {
        /// <summary>
        /// Method to perform the corresponding algorithm strategy
        /// </summary>
        /// <param name="tree">Tree where the algorithm will be executed</param>
        /// <param name="data">Optional information required if algorithm needed</param>
        void DoAlgorithm(BinarySearchTree tree, ElementDTO data = null);
    }
}