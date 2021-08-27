namespace View.EventController
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using View.GUI.ProjectedObjects;

    public class SelectionController : MonoBehaviour
    {
        //NOTE: this can be changed for a string to improve flexibility
        private Type _selectedType = null;
        private List<ProjectedObject> _selectedObjects;
        [SerializeField]
        private bool _monoSelection = false;

        /// <summary>
        /// Observer event to notify selection objects
        /// </summary>
        public static event Action<List<ProjectedObject>> UpdateMenu;

        public void Awake(){
            _selectedObjects = new List<ProjectedObject>();
        }
        public void Update()
        {
            ProjectedObject obj = GetRayCastedObject();
            if(obj?.IsSelectable() == true)
            {
                if(obj.IsSelected()){
                    DeselectObject(obj);
                }else{
                    SelectObject(obj);
                }
                UpdateMenu?.Invoke(this._selectedObjects);
            }
        }

        public List<ProjectedObject> GetSelectedObjects(){
            return _selectedObjects;
        }


        public void SelectObject(ProjectedObject obj){
            if(_selectedType != obj.GetType() || _monoSelection){
                DeselectAllObjects();
            }
            if(_selectedObjects.Count == 0){
                _selectedType = obj.GetType();
            }
            _selectedObjects.Add(obj);
            obj.SetSelected(true);
        }

        public void DeselectAllObjects(){
            foreach (ProjectedObject obj in _selectedObjects)
            {
                obj.SetSelected(false);
            }
            _selectedObjects.Clear();
            UpdateMenu?.Invoke(this._selectedObjects);
        }

        public void DeselectObject(ProjectedObject obj){
            obj.SetSelected(false);
            if(_monoSelection){
                DeselectAllObjects();
            }else{
                _selectedObjects.Remove(obj);
            }
        }

        private ProjectedObject GetRayCastedObject()
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