using UnityEngine;
using View.GUI.ProjectedObjects;
using Utils;

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
            Collider[] collidersInScene = Physics.OverlapSphere(_gameObject.transform.position, Constants.OjectPyshicsRepulsionDistance);
            foreach (Collider collider in collidersInScene)
            {
                Rigidbody colliderRigidBody = collider.attachedRigidbody;
                if (colliderRigidBody != null && colliderRigidBody != _gameObject.GetComponent<Rigidbody>())
                {
                    Vector3 repulsionDirection = collider.transform.position - _gameObject.transform.position;
                    // apply normalized distance
                    colliderRigidBody.AddForce(repulsionDirection * Constants.ObjectPyshicsRepulsionForce * Constants.OjectPyshicsRepulsionDistance);
                }
            }
        }

        public void AddLeftImpulse(){
            Vector3 impulseDirection = new Vector3(-5,0,0);
            Rigidbody rigidbody = _gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(impulseDirection, ForceMode.Impulse);
        }
    }
}