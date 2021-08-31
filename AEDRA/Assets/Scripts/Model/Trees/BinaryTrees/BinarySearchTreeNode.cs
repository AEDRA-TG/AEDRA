using System.Collections;
using Utils.Enums;
using SideCar.DTOs;
using Model.Common;

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
            BinarySearchTreeNode child=null;
            if(value > this.Value){
                child = this._rightChild;
            }
            else if(value < this.Value){
                child = this._leftChild;
            }
            if(child == null){
                child = new BinarySearchTreeNode(id, value);
            }
            else{
                child.AddElement(id, value);
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
                Operation = operation
            };
            DataStructure.Notify(dto);
        }
    }
}