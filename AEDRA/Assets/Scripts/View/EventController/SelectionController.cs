using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using View.GUI.ProjectedObjects;

namespace View.EventController
{
    /// <summary>
    /// Class to manage user objects selection
    /// </summary>
    public class SelectionController : MonoBehaviour
    {
        //NOTE: this can be changed for a string to improve flexibility
        /// <summary>
        /// Type of the selected object
        /// </summary>
        private Type _selectedType = null;

        /// <summary>
        /// List of the current selected objects
        /// </summary>
        private List<ProjectedObject> _selectedObjects;

        /// <summary>
        /// Boolean to indicate if the monoselection is enable
        /// </summary>
        [SerializeField] private bool _monoSelection = false;

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

        /// <summary>
        /// Method to select one projected object
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Method to deselect all projected objects previously selected
        /// </summary>
        public void DeselectAllObjects(){
            if(_selectedObjects.Count > 0 ){
                foreach (ProjectedObject obj in _selectedObjects)
                {
                    obj.SetSelected(false);
                }
                _selectedObjects.Clear();
                UpdateMenu?.Invoke(this._selectedObjects);
            }
        }

        /// <summary>
        /// Method to deselect one projected object
        /// </summary>
        /// <param name="obj"></param>
        public void DeselectObject(ProjectedObject obj){
            obj.SetSelected(false);
            if(_monoSelection){
                DeselectAllObjects();
            }else{
                _selectedObjects.Remove(obj);
            }
        }

        /// <summary>
        /// Method to obtain the object selected by the user
        /// </summary>
        /// <returns>The projected object asociated with the selected object</returns>
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

        /// <summary>
        /// Method to obtain the coordinates that where the user touched on the screen
        /// </summary>
        /// <returns>Touch position, null if the touch was not correct</returns>
        private Vector3? GetInputPosition()
        {
            Vector3? inputPosition = null;
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                if(!EventSystem.current.IsPointerOverGameObject()){
                    inputPosition = Input.mousePosition;
                }
            }
#elif UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
                        inputPosition = touch.position;
			        }
                }
            }
#endif
            return inputPosition;
        }
    }

}