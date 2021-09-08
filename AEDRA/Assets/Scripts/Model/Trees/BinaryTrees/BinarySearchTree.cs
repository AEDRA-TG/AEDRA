using Model.Common;
using SideCar.DTOs;
using Utils.Enums;

namespace Model.TreeModel
{
    public class BinarySearchTree : DataStructure
    {
        public BinarySearchTreeNode _root {get; set;}
        public int _nodesCount {get; set;}

        public BinarySearchTree(){
            this._nodesCount = 0;
            this._root = null;
        }
        public override void CreateDataStructure()
        {
            if(this._root != null){
                CreateTree( this._root, null);
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
            CreateTree(node._leftChild, node);
            CreateTree(node._rightChild, node);
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

        public override void DoTraversal(TraversalEnum traversalName, ElementDTO startNode)
        {
            throw new System.NotImplementedException();
        }
    }
}