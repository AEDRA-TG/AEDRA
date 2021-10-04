using UnityEngine;
using View.GUI.ProjectedObjects;
using Utils;
using SideCar.DTOs;
using DG.Tweening;

namespace View.GUI.ObjectsPhysics
{
    /// <summary>
    /// Class to manage the objects physics
    /// </summary>
    public class ObjectPhysics
    {
        /// <summary>
        /// Game object to be the physics will be applied
        /// </summary>
        private GameObject _gameObject;

        public ObjectPhysics(GameObject gameObject){
            this._gameObject = gameObject;
        }

        /// <summary>
        /// Mehtod that defines physics restrictions when data structure is graph
        /// </summary>
        public void ApplyGraphPhysics(){
            foreach (Collider closeCollider in Physics.OverlapSphere(_gameObject.transform.position, Constants.MinimalNodeDistance))
            {
                if (closeCollider != null && closeCollider != _gameObject.GetComponent<Collider>())
                {
                    Vector3 forceDirection = new Vector3(closeCollider.gameObject.transform.localPosition.x- _gameObject.transform.localPosition.x,0, closeCollider.gameObject.transform.localPosition.y- _gameObject.transform.localPosition.y);
                    AddForce(closeCollider.gameObject, forceDirection);
                }
            }
        }

        /// <summary>
        /// Method that defines physics restrictions when data structure is binary search tree
        /// </summary>
        public void ApplyBinaryTreePhysics(){
            this.RepulseHorizontal();
            this.CheckHorizontalToParentDistance();
            this.CheckHorizontalChildsDistance();
        }

        /// <summary>
        /// Method to control the horizontal repulsion on tree data structure
        /// </summary>
        private void RepulseHorizontal(){
            foreach(Collider closeCollider in Physics.OverlapSphere(_gameObject.transform.position, Constants.MinimalNodeDistance)){
                if(closeCollider != null && closeCollider != _gameObject.GetComponent<Collider>()){
                    Vector3 forceDirection = new Vector3(closeCollider.transform.localPosition.x - _gameObject.transform.localPosition.x, 0, 0);
                    AddForce(closeCollider.gameObject, forceDirection);
                }
            }
        }

        /// <summary>
        /// Method to control what happens when a node child is near to their parent
        /// </summary>
        private void CheckHorizontalToParentDistance(){
            BinarySearchNodeDTO dto = _gameObject.GetComponent<ProjectedObject>().Dto as BinarySearchNodeDTO;
            if(dto.ParentId != null){
                GameObject parent = GameObject.Find(Constants.NodeName + dto.ParentId);
                //Update children position so children will have the same parent deep
                _gameObject.transform.localPosition = new Vector3(_gameObject.transform.localPosition.x, parent.transform.localPosition.y, parent.transform.localPosition.z - Constants.VerticalNodeTreeDistance);
                BinarySearchNodeDTO parentDTO = parent.GetComponent<ProjectedObject>()?.Dto as BinarySearchNodeDTO;
                Vector3 distanceToParent = _gameObject.transform.localPosition- parent.transform.localPosition;
                if(Mathf.Abs(distanceToParent.x) < Constants.HorizontalChildToParentDistance){
                    Vector3 forceParentDirection;
                    Vector3 forceDirection;
                    if(dto.IsLeft){
                        forceDirection = new Vector3(-1,0,0);
                        forceParentDirection = new Vector3(1,0,0);
                    }else{
                        forceDirection = new Vector3(1,0,0);
                        forceParentDirection = new Vector3(-1,0,0);
                    }
                    if(parentDTO.ParentId != null){
                        AddForce(parent, forceParentDirection);
                    }
                    else{
                        AddForce(_gameObject, forceDirection);
                    }
                }
            }
        }

        /// <summary>
        /// Method that separates childs at the same parent distance
        /// </summary>
        private void CheckHorizontalChildsDistance(){
            BinarySearchNodeDTO dto = _gameObject.GetComponent<ProjectedObject>().Dto as BinarySearchNodeDTO;
            GameObject leftChild = null;
            GameObject rightChild = null;

            if(dto.LeftChild != null){
                leftChild = GameObject.Find(Constants.NodeName + dto.LeftChild);
            }
            if(dto.RightChild != null){
                rightChild = GameObject.Find(Constants.NodeName + dto.RightChild);
            }
            if(leftChild != null && rightChild != null){
                float distanceLeftToParent = Mathf.Sqrt(Mathf.Pow(leftChild.transform.localPosition.x - _gameObject.transform.localPosition.x, 2));
                float distanceRightToParent = Mathf.Sqrt(Mathf.Pow(rightChild.transform.localPosition.x - _gameObject.transform.localPosition.x, 2));
                float maxHorizontalDistanceToParent = Mathf.Max(distanceLeftToParent, distanceRightToParent);
                if(Mathf.Abs(maxHorizontalDistanceToParent - distanceLeftToParent) > 0.5){
                    AddForce(leftChild, new Vector3(-1, 0,0));
                }
                if(Mathf.Abs(maxHorizontalDistanceToParent - distanceRightToParent) > 0.5){
                    AddForce(rightChild, new Vector3(1,0,0));
                }
            }
        }

        /// <summary>
        /// Method that position an object when is created depending if it is left or right child
        /// </summary>
        public void PositionObject(){
            if(_gameObject.GetComponent<ProjectedObject>().Dto is BinarySearchNodeDTO dto){
                if(dto.ParentId != null){
                    if(dto.IsLeft){
                        AddForce(_gameObject,new Vector3(-1,0,0));
                    }
                    else{
                        AddForce(_gameObject, new Vector3(1,0,0));
                    }
                }
            }
        }

        private void AddForce(GameObject objectToMove, Vector3 forceDirection){
            Vector3 deltaMove = new Vector3(0.00f,0.00f,00f);
            if(forceDirection.x < 0){
                deltaMove.x = -0.01f;
            }
            else if(forceDirection.x > 0){
                deltaMove.x = 0.01f;
            }
            if(forceDirection.z < 0){
                deltaMove.z = -0.01f;
            }
            else if(forceDirection.z > 0){
                deltaMove.z= 0.01f;
            }
            objectToMove.transform.localPosition += deltaMove;
        }
    }
}