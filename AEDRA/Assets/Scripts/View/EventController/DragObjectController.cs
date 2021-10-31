using UnityEngine;
using View.GUI.ProjectedObjects;
using SideCar.DTOs;
using Utils;

namespace View.EventController
{
    public class DragObjectController : MonoBehaviour
    {
        private SelectionController selectionController;
        private Vector3 screenPosition = Vector3.zero;
        [SerializeField]
        private ProjectedObject projObj = null;
        private GameObject brother = null;
        private int? brotherId = null;
        private BinarySearchNodeDTO parentBinaryDTO;
        public void Start()
        {
            selectionController = GameObject.FindObjectOfType<SelectionController>();
            if (projObj?.Dto is BinarySearchNodeDTO binaryDTO)
            {
                GameObject parentNode = GameObject.Find(Constants.NodeName + binaryDTO.ParentId);
                parentBinaryDTO = (BinarySearchNodeDTO)parentNode?.GetComponent<ProjectedObject>().Dto;
            }
        }

        public void OnMouseDrag()
        {
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 inputPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(inputPosition);
            currentPosition = transform.parent.InverseTransformPoint(currentPosition);
            currentPosition.y = 0;
            if (projObj?.Dto is BinarySearchNodeDTO binaryDTO)
            {
                currentPosition.z = transform.localPosition.z;
                if (parentBinaryDTO != null && !CanUpdate(binaryDTO, currentPosition))
                {
                    return;
                }
            }
            transform.localPosition = currentPosition;
        }

        private bool CanUpdate(BinarySearchNodeDTO binaryDTO, Vector3 currentPosition)
        {
            if (binaryDTO.IsLeft)
            {
                if (brotherId != parentBinaryDTO.RightChild)
                {
                    Debug.Log("Find right brother");
                    brother = GameObject.Find(Constants.NodeName + parentBinaryDTO.RightChild);
                    brotherId = parentBinaryDTO.RightChild;
                }
            }
            else if (brotherId != parentBinaryDTO.LeftChild)
            {
                Debug.Log("Find left brother");
                brother = GameObject.Find(Constants.NodeName + parentBinaryDTO.LeftChild);
                brotherId = parentBinaryDTO.LeftChild;
            }

            if (brother != null)
            {
                if (binaryDTO.IsLeft)
                {
                    if (currentPosition.x > brother?.transform.localPosition.x)
                    {
                        return false;
                    }
                }
                else
                {
                    if (currentPosition.x < brother?.transform.localPosition.x)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}