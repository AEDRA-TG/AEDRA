using System.Collections.Generic;
using Model.Common;
using Model.TreeModel.BinaryTree.Traversals;
using SideCar.DTOs;
using Utils.Enums;

namespace Model.TreeModel
{
    public class BinarySearchTree : DataStructure
    {
        private BinarySearchTreeNode _root;
        private int _nodesCount;
        private Dictionary<TraversalEnum, ITraversalTreeStrategy> _traversals;

        public BinarySearchTree(){
            this._nodesCount = 0;
            this._root = null;
            _traversals = new Dictionary<TraversalEnum, ITraversalTreeStrategy>() {
                {TraversalEnum.TreePreOrder, new PreOrderTraversalStrategy()},
                {TraversalEnum.TreeInOrder, new InOrderTraversalStrategy()},
                {TraversalEnum.TreePostOrder, new PostOrderTraversalStrategy()}
            };
        }
        public override void CreateDataStructure()
        {
        }

        public override void AddElement(ElementDTO element)
        {
            if(this._root != null && this._root.Value!=(int)element.Value){
                this._root.NotifyNode(null, this._root, AnimationEnum.PaintAnimation);
                this._root.AddElement(this._nodesCount, (int)element.Value);
                this._nodesCount++;
            }
            else if(this._root == null){
                this._root = new BinarySearchTreeNode(this._nodesCount, (int)element.Value);
                this._root.NotifyNode(null, this._root, AnimationEnum.CreateAnimation);
                this._nodesCount++;
            }
        }

        public override void DeleteElement(ElementDTO element)
        {
            if(this._root !=null){
                if(this._root.IsLeaf() && this._root.Value == (int)element.Value){
                    this._root.NotifyNode(null, this._root, AnimationEnum.DeleteAnimation);
                    this._root = null;
                }
                else{
                    this._root.NotifyNode(null, this._root, AnimationEnum.PaintAnimation);
                    this._root.DeleteElement((int)element.Value);
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
            return _root;
        }
    }
}