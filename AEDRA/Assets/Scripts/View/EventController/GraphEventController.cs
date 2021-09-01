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
    public class GraphEventController : MonoBehaviour
    {

        private SelectionController _selectionController;
        public static event Action<int> UpdateMenu;

        public void Awake()
        {
            _selectionController = FindObjectOfType<SelectionController>();
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
                    GraphEdgeDTO edgeDTO = new GraphEdgeDTO(0, 0, objs[0].Dto.Id, objs[1].Dto.Id);
                    ConnectElementsCommand connectCommand = new ConnectElementsCommand(edgeDTO);
                    CommandController.GetInstance().Invoke(connectCommand);
                }
            }
            else
            {
                Debug.Log("Numero de nodos seleccionados inválido");
            }
        }

        //TODO: review this method
        public void ChangeToTraversalMenu(){
            UpdateMenu?.Invoke(0);
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

        //TODO: Revisar paso de parametros, This method should not be here
        public void ChangeMenu(int menu){
            OptionsMenu optionsMenu = FindObjectOfType<OptionsMenu>();
            //TODO: Refactor this code, pliiis
            switch(menu) {
                case 0:
                    optionsMenu.LoadPrefab(Constants.PathAddElementInputMenu, "InputMenu", "ProjectionLayout");
                    break;
            }
        }
    }
}