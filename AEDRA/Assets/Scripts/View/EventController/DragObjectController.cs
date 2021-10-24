using UnityEngine;
using View.GUI.ProjectedObjects;

namespace View.EventController
{
    public class DragObjectController : MonoBehaviour
    {
        private SelectionController selectionController;
        private bool _isMouseDrag;
        private Vector3 screenPosition = Vector3.zero;
        private Vector3 offset = Vector3.zero;

        private ProjectedObject target = null;

        public void Start(){
            selectionController = GameObject.FindObjectOfType<SelectionController>();
        }
        public void Update()
        {
            //if touched screen
            if (Input.GetMouseButtonDown(0))
            {
                //get touched object
                target = selectionController.GetRayCastedObject();
                if (target != null)
                {
                    _isMouseDrag = true;
                    //Convert world position to screen position.
                    screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                    offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isMouseDrag = false;
            }

            if (_isMouseDrag)
            {
                //track mouse position.
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

                //convert screen position to world position with offset changes.
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
                //It will update target gameobject's current postion.
                target.transform.position = currentPosition;
            }

        }
    }
}