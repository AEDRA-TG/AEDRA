namespace View.EventController
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using View.GUI.ProjectedObjects;

    public class SelectionController : MonoBehaviour
    {
        //NOTE: this can be changed for a string to improve flexibility
        private Type _selectedType;
        public List<ProjectedObject> SelectedObjects{get; set;}

        public void Awake(){
            SelectedObjects = new List<ProjectedObject>();
        }
        public void Update()
        {
            ProjectedObject obj = GetSelectedObject();
            if(obj?.IsSelectable() == true)
            {
                if(obj.IsSelected()){
                    Debug.Log("Deselect");
                    DeselectObject(obj);
                }else{
                    Debug.Log("Select");
                    SelectObject(obj);
                }
            }
        }

        public void SelectObject(ProjectedObject obj){
            if(SelectedObjects.Count == 0){
                _selectedType = obj.GetType();
            }
            if(_selectedType != obj.GetType()){
                DeselectAllObjects();
            }
            SelectedObjects.Add(obj);
            obj.SetSelected(true);
        }

        public void DeselectAllObjects(){
            foreach (ProjectedObject obj in SelectedObjects)
            {
                DeselectObject(obj);
            }
        }

        public void DeselectObject(ProjectedObject obj){
            SelectedObjects.Remove(obj);
            obj.SetSelected(false);
        }

        private ProjectedObject GetSelectedObject()
        {
            Vector3? inputPosition = GetInputPosition();
            ProjectedObject selectedObject = null;
            if(inputPosition != null){
                Ray ray = Camera.main.ScreenPointToRay((Vector3)inputPosition);
                if (Physics.Raycast(ray, out RaycastHit hitObject))
                {
                    selectedObject = hitObject.transform.GetComponent<ProjectedObject>();
                }
            }
            return selectedObject;
        }

        private Vector3? GetInputPosition()
        {
            Vector3? inputPosition = null;
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                inputPosition = Input.mousePosition;
            }
#elif UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    inputPosition = touch.position;
                }
            }
#endif
            return inputPosition;
        }
    }

}