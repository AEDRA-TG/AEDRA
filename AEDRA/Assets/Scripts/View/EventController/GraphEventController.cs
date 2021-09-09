using UnityEngine;
using Controller;
using SideCar.DTOs;
using View.GUI;
using View.GUI.ProjectedObjects;
using System.Collections.Generic;
using Utils.Enums;
using System;
using Utils;
using UnityEngine.UI;

namespace View.EventController
{
    /// <summary>
    /// Class to manage events received from an action executed on a graph by the user
    /// </summary>
    public class GraphEventController : AppEventController
    {

        private SelectionController _selectionController;

        public void Start(){
            _selectionController = FindObjectOfType<SelectionController>();
            base._menus = new Dictionary<MenuEnum, GameObject>();
            base._menus.Add(MenuEnum.MainMenu, gameObject.transform.Find("MainMenu").gameObject);
            base._menus.Add(MenuEnum.TraversalMenu, gameObject.transform.Find("TraversalMenu").gameObject);
            base._menus.Add(MenuEnum.NodeSelectionMenu, gameObject.transform.Find("NodeSelectionMenu").gameObject);
            base._menus.Add(MenuEnum.NodeMultiSelectionMenu, gameObject.transform.Find("NodeMultiSelectionMenu").gameObject);
            base._menus.Add(MenuEnum.AddElementInputMenu, gameObject.transform.Find("AddElementInputMenu").gameObject);
            base._activeSubMenu = MenuEnum.MainMenu;
        }

        public void OnEnable() {
            SelectionController.UpdateMenu += UpdateMenuOnSelection;
        }

        public void OnDisable() {
            SelectionController.UpdateMenu -= UpdateMenuOnSelection;
        }

        private void UpdateMenuOnSelection(List<ProjectedObject> selectedObjects){
            switch(selectedObjects.Count){
                case 0: base.ChangeToMenu(MenuEnum.MainMenu);
                break;
                case 1: base.ChangeToMenu(MenuEnum.NodeSelectionMenu);
                break;
                default: base.ChangeToMenu(MenuEnum.NodeMultiSelectionMenu);
                break;
            }
        }

        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode()
        {
            string value = FindObjectOfType<InputField>().text;
            //TODO: Obtener el dto de los datos de la pantalla
            List<int> neighbors = new List<int>();
            GraphNodeDTO nodeDTO = new GraphNodeDTO(0, value, neighbors);
            AddElementCommand addCommand = new AddElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(addCommand);
        }

        /// <summary>
        /// Method to detect when the user taps on delete node button
        /// </summary>
        public void OnTouchDeleteNode()
        {
            List<ProjectedObject> objs = _selectionController.GetSelectedObjects();
            if (objs.Count == 1 && objs[0].GetType() == typeof(ProjectedNode))
            {
                    GraphNodeDTO nodeDTO = (GraphNodeDTO)objs[0].Dto;
                    DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
                    CommandController.GetInstance().Invoke(deleteCommand);
            }
            else
            {
                Debug.Log("Numero de nodos seleccionados inválido");
            }
        }

        /// <summary>
        /// Method to detect when the user taps the on connect node button
        /// </summary>
        public void OnTouchConnectNodes()
        {
            List<ProjectedObject> objs = _selectionController.GetSelectedObjects();
            if (objs.Count == 2)
            {
                if(objs[0].GetType() == typeof(ProjectedNode) && objs[1].GetType() == typeof(ProjectedNode)){
                    Debug.Log(objs[0].Dto.Id+ "-" + objs[1].Dto.Id );
                    EdgeDTO edgeDTO = new EdgeDTO(0, 0, objs[0].Dto.Id, objs[1].Dto.Id);
                    ConnectElementsCommand connectCommand = new ConnectElementsCommand(edgeDTO);
                    CommandController.GetInstance().Invoke(connectCommand);
                }
            }
            else
            {
                Debug.Log("Numero de nodos seleccionados inválido");
            }
        }

        public void DoTraversalBFS(){
            List<ProjectedObject> objs = _selectionController.GetSelectedObjects();
            if (objs.Count == 1 && objs[0].GetType() == typeof(ProjectedNode))
            {
                    GraphNodeDTO nodeDTO = (GraphNodeDTO)objs[0].Dto;
                    DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.GraphBFS,nodeDTO);
                    CommandController.GetInstance().Invoke(traversalCommand);
            }
            else
            {
                Debug.Log("Numero de nodos seleccionados inválido");
            }
        }

        public void DoTraversalDFS(){
            List<ProjectedObject> objs = _selectionController.GetSelectedObjects();
            if (objs.Count == 1 && objs[0].GetType() == typeof(ProjectedNode))
            {
                    GraphNodeDTO nodeDTO = (GraphNodeDTO)objs[0].Dto;
                    DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.GraphDFS,nodeDTO);
                    CommandController.GetInstance().Invoke(traversalCommand);
            }
            else
            {
                Debug.Log("Numero de nodos seleccionados inválido");
            }
        }
    }
}