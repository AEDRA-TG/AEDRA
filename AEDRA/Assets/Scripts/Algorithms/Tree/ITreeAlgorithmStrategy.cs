using Model.TreeModel;
using SideCar.DTOs;

namespace Algorithms.Tree
{
    /// <summary>
    /// Interface that defines tree algorithm strategy
    /// </summary>
    public interface ITreeAlgorithmStrategy
    {
        /// <summary>
        /// Method to perform the corresponding algorithm strategy
        /// </summary>
        /// <param name="tree">Tree where the algorithm will be executed</param>
        /// <param name="data">Optional information required if algorithm needed</param>
        void DoAlgorithm(BinarySearchTree tree, ElementDTO data = null);
    }
}