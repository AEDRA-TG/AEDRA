using Utils.Enums;
using SideCar.DTOs;
using Model.Common;

namespace Model.TreeModel
{
    public class BinarySearchTreeNode
    {
        public int Id{get;set;}
        public int Value {get; set;}
        public BinarySearchTreeNode LeftChild {get; set;}
        public BinarySearchTreeNode RightChild {get; set;}
        public Point Coordinates {get; set;}

        public BinarySearchTreeNode(int id, int value){
            this.Id = id;
            this.Value = value;
            this.Coordinates = new Point(0,0,0);
        }

        public bool IsLeaf(){
            return this.LeftChild == null && this.RightChild == null;
        }

        public void AddElement(int id, int value){
            if(value > this.Value){
                if(this.RightChild!=null){
                    NotifyEdge(this, this.RightChild, AnimationEnum.PaintAnimation);
                    NotifyNode(this, this.RightChild, AnimationEnum.PaintAnimation);
                    this.RightChild.AddElement(id,value);
                }
                else{
                    this.RightChild = new BinarySearchTreeNode(id, value);
                    NotifyNode(null, this, AnimationEnum.UpdateAnimation);
                    NotifyNode(this,this.RightChild, AnimationEnum.CreateAnimation);
                    NotifyEdge(this, this.RightChild, AnimationEnum.CreateAnimation);
                }
            }
            else if(value < this.Value){
                if(this.LeftChild!=null){
                    NotifyEdge(this, this.LeftChild, AnimationEnum.PaintAnimation);
                    NotifyNode(this, this.LeftChild, AnimationEnum.PaintAnimation);
                    this.LeftChild.AddElement(id,value);
                }
                else{
                    this.LeftChild = new BinarySearchTreeNode(id, value);
                    NotifyNode(null, this, AnimationEnum.UpdateAnimation);
                    NotifyNode(this,this.LeftChild, AnimationEnum.CreateAnimation);
                    NotifyEdge(this, this.LeftChild, AnimationEnum.CreateAnimation);
                }
            }
        }

        public void DeleteElement(int value){
            if(value > this.Value){
                if(this.RightChild != null){
                    if(value == this.RightChild.Value){
                        NotifyNode(null, this, AnimationEnum.UpdateAnimation);
                        NotifyEdge(this, this.RightChild, AnimationEnum.DeleteAnimation);
                        NotifyNode(this, this.RightChild, AnimationEnum.DeleteAnimation);
                        this.RightChild = null;
                    }
                    else{
                        NotifyEdge(this, this.RightChild, AnimationEnum.PaintAnimation);
                        NotifyNode(this, this.RightChild, AnimationEnum.PaintAnimation);
                        this.RightChild.DeleteElement(value);
                    }
                }
            }
            else if(value < this.Value){
                if(this.LeftChild != null){
                    if(value == this.LeftChild.Value){
                        NotifyNode(null, this, AnimationEnum.UpdateAnimation);
                        NotifyEdge(this, this.LeftChild, AnimationEnum.DeleteAnimation);
                        NotifyNode(this, this.LeftChild, AnimationEnum.DeleteAnimation);
                        this.LeftChild = null;
                    }
                    else{
                        NotifyEdge(this, this.LeftChild, AnimationEnum.PaintAnimation);
                        NotifyNode(this, this.LeftChild, AnimationEnum.PaintAnimation);
                        this.LeftChild.DeleteElement(value);
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
                if(parent.LeftChild != null && parent.LeftChild.Value == node.Value){
                    isLeft = true;
                }
            }
            BinarySearchNodeDTO dto = new BinarySearchNodeDTO(node.Id, node.Value, parentId, isLeft, node.LeftChild?.Id, node.RightChild?.Id){
                Operation = operation,
                Coordinates = this.Coordinates
            };
            DataStructure.Notify(dto);
        }
    }
}