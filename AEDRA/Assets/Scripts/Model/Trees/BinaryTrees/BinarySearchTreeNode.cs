using System.Collections;
using Utils.Enums;
using SideCar.DTOs;
using Model.Common;
using UnityEngine; // REMOVE THIS IMPORT

namespace Model.TreeModel
{
    public class BinarySearchTreeNode
    {
        public int Id{get;set;}
        public int Value {get; set;}
        private BinarySearchTreeNode _leftChild;
        private BinarySearchTreeNode _rightChild;

        public BinarySearchTreeNode(int id, int value){
            this.Id = id;
            this.Value = value;
        }

        public bool IsLeaf(){
            return this._leftChild == null && this._rightChild == null;
        }

        public void AddElement(int id, int value){
            if(value > this.Value){
                if(this._rightChild!=null){
                    NotifyNode(this, this._rightChild, AnimationEnum.PaintAnimation);
                    this._rightChild.AddElement(id,value);
                }
                else{
                    this._rightChild = new BinarySearchTreeNode(id, value);
                    NotifyNode(this,this._rightChild, AnimationEnum.CreateAnimation);
                }
            }
            else if(value < this.Value){
                if(this._leftChild!=null){
                    NotifyNode(this, this._leftChild, AnimationEnum.PaintAnimation);
                    this._leftChild.AddElement(id,value);
                }
                else{
                    this._leftChild = new BinarySearchTreeNode(id, value);
                    NotifyNode(this,this._leftChild, AnimationEnum.CreateAnimation);
                }
            }
        }

        public void DeleteElement(int value){
            if(value > this.Value){
                if(this._rightChild != null){
                    if(value == this._rightChild.Value){
                        this._rightChild = null;
                    }
                    else{
                        this._rightChild.DeleteElement(value);
                    }
                }
            }
            else if(value < this.Value){
                if(this._leftChild != null){
                    if(value == this._leftChild.Value){
                        this._leftChild = null;
                    }
                    else{
                        this._leftChild.DeleteElement(value);
                    }
                }
            }
        }

        public void NotifyEdge(BinarySearchTreeNode parent, BinarySearchTreeNode node, AnimationEnum operation){
            EdgeDTO dto = new EdgeDTO(0, node.Value, parent.Id, node.Id)
            {
                Operation = operation
            };
            DataStructure.Notify(dto);
        }

        public void NotifyNode(BinarySearchTreeNode parent, BinarySearchTreeNode node, AnimationEnum operation){
            int? parentId = null;
            bool isLeft = false;
            if(parent != null){
                parentId = parent.Id;
                if(parent._leftChild != null && parent._leftChild.Value == node.Value){
                    isLeft = true;
                }
            }
            BinarySearchNodeDTO dto = new BinarySearchNodeDTO(node.Id, node.Value, parentId, isLeft, node._leftChild?.Id, node._rightChild?.Id){
                Operation = operation,
                Coordinates = new Point(0,0,0)
            };
            DataStructure.Notify(dto);
        }
    }
}