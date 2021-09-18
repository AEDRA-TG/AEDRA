using System.Collections.Generic;
using Model.Common;
using Model.TreeModel.BinaryTree.Traversals;
using SideCar.DTOs;
using Utils.Enums;

namespace Model.TreeModel
{
    public class BinarySearchTree : DataStructure
    {
        public BinarySearchTreeNode Root {get; set;}
        public int NodesCount {get; set;}
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
        public override void CreateDataStructure()
        {
            if(this.Root != null){
                CreateTree( this.Root, null);
            }
        }

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

        public override void UpdateElement(ElementDTO element)
        {
            //TODO: ver que hacer con este método
            throw new System.NotImplementedException();
        }
    }
}