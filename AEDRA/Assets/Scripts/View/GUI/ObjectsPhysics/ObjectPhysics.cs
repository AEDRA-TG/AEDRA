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

        public void RepulseObject(){
            //Get the active colliders in scene
            Collider[] collidersInScene = Physics.OverlapSphere(_gameObject.transform.position, Constants.OjectPhysicsRepulsionDistance);
            foreach (Collider collider in collidersInScene)
            {
                Rigidbody colliderRigidBody = collider.attachedRigidbody;
                if (colliderRigidBody != null && colliderRigidBody != _gameObject.GetComponent<Rigidbody>())
                {
                    Vector3 repulsionDirection;
                    if (_gameObject.GetComponent<ProjectedObject>().Dto is BinarySearchNodeDTO dto){
                        repulsionDirection = new Vector3(collider.transform.position.x - _gameObject.transform.position.x, 0, 0);
                        colliderRigidBody.AddForce(repulsionDirection * Constants.ObjectPhysicsRepulsionForce * Constants.ObjectPhysicsRepulsionHorizontalDistance);
                    }
                    else{
                        repulsionDirection = collider.transform.position - _gameObject.transform.position;
                        colliderRigidBody.AddForce(repulsionDirection * Constants.ObjectPhysicsRepulsionForce * Constants.OjectPhysicsRepulsionDistance);
                    }
                }
            }
        }

        public void ParentPosition(){
            if (_gameObject.GetComponent<ProjectedObject>().Dto is BinarySearchNodeDTO dto){
                if(dto.LeftChild != null){
                    GameObject leftChild = GameObject.Find(Constants.NodeName + dto.LeftChild);
                    if(leftChild != null){
                        if(dto.RightChild != null){
                            GameObject rightChild = GameObject.Find(Constants.NodeName + dto.RightChild);
                            if(rightChild != null){
                                Vector3 distanceLeftToParent = leftChild.transform.position - _gameObject.transform.position;
                                Vector3 distanceRightToParent = rightChild.transform.position - _gameObject.transform.position;
                                if(Mathf.Abs(distanceRightToParent.x) < Mathf.Abs(distanceLeftToParent.x)){
                                    rightChild.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Abs(distanceLeftToParent.x),0,0)*Constants.ObjectPhysicsRepulsionForce*Constants.OjectPhysicsRepulsionDistance);
                                }
                            }
                        }
                    }
                }
                if(dto.ParentId != null){
                    GameObject parentObject = GameObject.Find(Constants.NodeName + dto.ParentId);
                    _gameObject.transform.position =  new Vector3(_gameObject.transform.position.x,parentObject.transform.position.y-3,_gameObject.transform.position.z);
                    Vector3 distance = _gameObject.transform.position - parentObject.transform.position;
                    if(Mathf.Abs(distance.x) < Constants.OjectPhysicsRepulsionDistance){
                        Rigidbody parentRigidBody = parentObject.GetComponent<Rigidbody>();
                        Vector3 impulseDirection = new Vector3(-1, 0, 0);
                        if(!dto.IsLeft){
                            parentRigidBody.AddForce(impulseDirection*Constants.ObjectPhysicsRepulsionForce*Constants.OjectPhysicsRepulsionDistance);
                        }else{
                            _gameObject.GetComponent<Rigidbody>().AddForce(impulseDirection);
                        }
                    }
                }
            }
        }
    }
}