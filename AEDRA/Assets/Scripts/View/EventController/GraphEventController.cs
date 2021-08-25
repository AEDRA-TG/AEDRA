using UnityEngine;
using Controller;
using SideCar.DTOs;
using Utils.Enums;
using View.GUI.ProjectedObjects;
using System.Collections.Generic;

namespace View.EventController
{
    /// <summary>
    /// Class to manage events received from an action executed on a graph by the user
    /// </summary>
    public class GraphEventController : MonoBehaviour
    {

        private SelectionController _selectionController;

        public void Awake()
        {
            _selectionController = FindObjectOfType<SelectionController>();
        }
        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode()
        {
            //TODO: Obtener el dto de los datos de la pantalla
            GraphNodeDTO nodeDTO = new GraphNodeDTO(0, 0, null);
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
                    //Debug.Log(objs[0].Dto.Id+ "-" + objs[1].Dto.Id );
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
    }
}