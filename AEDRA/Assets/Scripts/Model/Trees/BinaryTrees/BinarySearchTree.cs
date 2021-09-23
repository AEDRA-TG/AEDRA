using System.Collections.Generic;
using Model.Common;
using Model.TreeModel.BinaryTree.Traversals;
using SideCar.DTOs;
using Utils.Enums;

namespace Model.TreeModel
{
    /// <summary>
    /// Class to manage operations and data related to a Binary Search Tree
    /// </summary>
    public class BinarySearchTree : DataStructure
    {
        /// <summary>
        /// Tree node root
        /// </summary>
        /// <value>Null when tree is created</value>
        public BinarySearchTreeNode Root {get; set;}

        /// <summary>
        /// Number of binary search tree nodes
        /// </summary>
        /// <value>0 when tree is created</value>
        public int NodesCount {get; set;}

        /// <summary>
        /// Dictionary to save all the tree traversals implementations
        /// </summary>
        private Dictionary<TraversalEnum, ITraversalTreeStrategy> _traversals;

        public BinarySearchTree(){
            this.NodesCount = 0;
            this.Root = null;
            _traversals = new Dictionary<TraversalEnum, ITraversalTreeStrategy>() {
                {TraversalEnum.TreePreOrder, new PreOrderTraversalStrategy()},
                {TraversalEnum.TreeInOrder, new InOrderTraversalStrategy()},
                {TraversalEnum.TreePostOrder, new PostOrderTraversalStrategy()}
            };
        }

        /// <summary>
        /// Created an saved tree
        /// </summary>
        public override void CreateDataStructure()
        {
            if(this.Root != null){
                CreateTree( this.Root, null);
            }
        }

        /// <summary>
        /// Created an tree recursively
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        public void CreateTree(BinarySearchTreeNode node, BinarySearchTreeNode parent)
        {
            if(node==null)
            {
                return;
            }
            node.NotifyNode(parent, node, AnimationEnum.CreateAnimation);
            if(parent!=null)
            {
                node.NotifyEdge(parent, node, AnimationEnum.CreateAnimation);
            }
            CreateTree(node.LeftChild, node);
            CreateTree(node.RightChild, node);
        }

        /// <summary>
        /// Method to add a node on the tree
        /// </summary>
        /// <param name="element">Node informatión to add</param>
        public override void AddElement(ElementDTO element)
        {
            if(this.Root != null && this.Root.Value!=(int)element.Value){
                this.Root.NotifyNode(null, this.Root, AnimationEnum.PaintAnimation);
                this.Root.AddElement(this.NodesCount, (int)element.Value);
                this.NodesCount++;
            }
            else if(this.Root == null){
                this.Root = new BinarySearchTreeNode(this.NodesCount, (int)element.Value);
                this.Root.NotifyNode(null, this.Root, AnimationEnum.CreateAnimation);
                this.NodesCount++;
            }
        }

        /// <summary>
        /// Method to delete a node of the tree
        /// </summary>
        /// <param name="element">Node information to delete</param>
        public override void DeleteElement(ElementDTO element)
        {
            if(this.Root !=null){
                if(this.Root.IsLeaf() && this.Root.Value == (int)element.Value){
                    this.Root.NotifyNode(null, this.Root, AnimationEnum.DeleteAnimation);
                    this.Root = null;
                }
                else{
                    this.Root.NotifyNode(null, this.Root, AnimationEnum.PaintAnimation);
                    this.Root.DeleteElement((int)element.Value);
                }
            }
        }

        /// <summary>
        /// Method to do a traversal on the tree
        /// </summary>
        /// <param name="traversalName">Enum of the traversal to execute</param>
        public override void DoTraversal(TraversalEnum traversalName, ElementDTO data = null)
        {
            this._traversals[traversalName].DoTraversal(this);
        }

        public BinarySearchTreeNode GetRoot(){
            return Root;
        }

        /// <summary>
        /// Method that update a node information
        /// </summary>
        /// <param name="element">Node information to update</param>
        public override void UpdateElement(ElementDTO element)
        {
            //TODO: ver que hacer con este método
        }
    }
}