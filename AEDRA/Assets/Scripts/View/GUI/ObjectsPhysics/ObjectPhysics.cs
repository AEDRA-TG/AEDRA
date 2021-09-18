using UnityEngine;
using View.GUI.ProjectedObjects;
using Utils;
using SideCar.DTOs;

namespace View.GUI.ObjectsPhysics
{
    public class ObjectPhysics
    {
        private GameObject _gameObject;

        public ObjectPhysics(GameObject gameObject){
            this._gameObject = gameObject;
        }

        public void ApplyGraphPhysics(){
            foreach (Collider closeCollider in Physics.OverlapSphere(_gameObject.transform.position, Constants.MinimalNodeDistance))
            {
                Rigidbody colliderRigidBody = closeCollider.attachedRigidbody;
                if (colliderRigidBody != null && colliderRigidBody != _gameObject.GetComponent<Rigidbody>())
                {
                    Vector3 forceDirection = new Vector3(colliderRigidBody.transform.position.x- _gameObject.transform.position.x, colliderRigidBody.transform.position.y- _gameObject.transform.position.y,0);
                    AddForce(colliderRigidBody.gameObject, forceDirection , Constants.HorizontalForce * Constants.MinimalNodeDistance, ForceMode.Force);
                }
            }
        }

        public void ApplyBinaryTreePhysics(){
            RepulseHorizontal();
            CheckHorizontalToParentDistance();
            CheckHorizontalChildsDistance();
        }

        private void RepulseHorizontal(){
            foreach(Collider closeCollider in Physics.OverlapSphere(_gameObject.transform.position, Constants.MinimalNodeDistance)){
                Rigidbody closeRigidBody = closeCollider.attachedRigidbody;
                if(closeRigidBody != null && closeRigidBody != _gameObject.GetComponent<Rigidbody>()){
                    Vector3 forceDirection = new Vector3(closeCollider.transform.position.x - _gameObject.transform.position.x, 0, 0);
                    AddForce(closeRigidBody.gameObject, forceDirection, Constants.HorizontalForce, ForceMode.Force);
                }
            }
        }

        private void CheckHorizontalToParentDistance(){
            BinarySearchNodeDTO dto = _gameObject.GetComponent<ProjectedObject>().Dto as BinarySearchNodeDTO;
            if(dto.ParentId != null){
                GameObject parent = GameObject.Find(Constants.NodeName + dto.ParentId);
                _gameObject.transform.position= new Vector3(_gameObject.transform.position.x, parent.transform.position.y - Constants.VerticalNodeTreeDistance,parent.transform.position.z);
                BinarySearchNodeDTO parentDTO = parent.GetComponent<ProjectedObject>()?.Dto as BinarySearchNodeDTO;
                Vector3 distanceToParent = _gameObject.transform.position- parent.transform.position;
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
                        AddForce(parent, forceParentDirection, Constants.MinimalHorizontalForce, ForceMode.Force);
                    }
                    else{
                        AddForce(_gameObject, forceDirection, Constants.MinimalHorizontalForce, ForceMode.Force);
                    }
                }
            }
        }

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
                float distanceLeftToParent = Mathf.Sqrt(Mathf.Pow(leftChild.transform.position.x - _gameObject.transform.position.x, 2));
                float distanceRightToParent = Mathf.Sqrt(Mathf.Pow(rightChild.transform.position.x - _gameObject.transform.position.x, 2));
                float maxHorizontalDistanceToParent = Mathf.Max(distanceLeftToParent, distanceRightToParent);
                if(Mathf.Abs(maxHorizontalDistanceToParent - distanceLeftToParent) > 0.5){
                    AddForce(leftChild, new Vector3(-1, 0,0), Constants.MinimalHorizontalForce, ForceMode.Force);
                }
                if(Mathf.Abs(maxHorizontalDistanceToParent - distanceRightToParent) > 0.5){
                    AddForce(rightChild, new Vector3(1,0,0), Constants.MinimalHorizontalForce, ForceMode.Force);
                }
            }
        }

        public void PositionObject(){
            if(_gameObject.GetComponent<ProjectedObject>().Dto is BinarySearchNodeDTO dto){
                if(dto.ParentId != null){
                    if(dto.IsLeft){
                        AddForce(_gameObject,new Vector3(-1,0,0), Constants.HorizontalForce, ForceMode.Impulse);
                    }
                    else{
                        AddForce(_gameObject, new Vector3(1,0,0), Constants.HorizontalForce, ForceMode.Impulse);
                    }
                }
            }
        }

        private void AddForce(GameObject objectToApply, Vector3 forceDirection, float forceToApply, ForceMode forceMode){
            objectToApply.GetComponent<Rigidbody>()?.AddForce(forceDirection * forceToApply, forceMode);
        }
    }
}