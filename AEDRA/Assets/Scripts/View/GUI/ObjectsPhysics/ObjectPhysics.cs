using UnityEngine;
using View.GUI.ProjectedObjects;
using Utils;

namespace View.GUI.ObjectsPhysics
{
    public class ObjectPhysics
    {

        public void RepulseObject(GameObject gameObject){
            //Get the active colliders in scene
            Collider[] collidersInScene = Physics.OverlapSphere(gameObject.transform.position, Constants.OjectPyshicsRepulsionDistance);
            foreach (Collider collider in collidersInScene)
            {
                Rigidbody colliderRigidBody = collider.attachedRigidbody;
                if (colliderRigidBody != null && colliderRigidBody != gameObject.GetComponent<Rigidbody>())
                {
                    Vector3 repulsionDirection = collider.transform.position - gameObject.transform.position;
                    // apply normalized distance
                    colliderRigidBody.AddForce(repulsionDirection * Constants.ObjectPyshicsRepulsionForce * Constants.OjectPyshicsRepulsionDistance);
                }
            }
        }
    }
}