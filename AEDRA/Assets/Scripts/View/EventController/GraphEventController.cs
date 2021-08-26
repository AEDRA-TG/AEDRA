using UnityEngine;
using Controller;
using Model.GraphModel;
using SideCar.DTOs;
using Utils.Enums;
using System.Collections.Generic;

namespace View.EventController
{
    /// <summary>
    /// Class to manage events received from an action executed on a graph by the user
    /// </summary>
    public class GraphEventController : MonoBehaviour
    {

        // TODO : BORRAR
        [SerializeField] private int id;
        [SerializeField] private int id2;

        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode()
        {
            //TODO: Obtener el dto de los datos de la pantalla
            List<int> neighbors = new List<int>{};
            GraphNodeDTO nodeDTO = new GraphNodeDTO(0, 0, neighbors);
            AddElementCommand addCommand = new AddElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(addCommand);
        }

        /// <summary>
        /// Method to detect when the user taps on delete node button
        /// </summary>
        public void OnTouchDeleteNode()
        {
            // TODO: Get selected object
            // Convert selected object to DTO

            // Remove this when select objects funtionality is implemented
            List<int> neighbors = new List<int>{ 1 , 2 };

            GraphNodeDTO nodeDTO = new GraphNodeDTO(id, 0, neighbors);
            DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(deleteCommand);
        }

        /// <summary>
        /// Method to detect when the user taps the on connect node button
        /// </summary>
        public void OnTouchConnectNodes()
        {
            //TODO: fix element selection to obtain edge
            GraphEdgeDTO edgeDTO = new GraphEdgeDTO(0, 0, id, id2);
            ConnectElementsCommand connectCommand = new ConnectElementsCommand(edgeDTO);
            CommandController.GetInstance().Invoke(connectCommand);
        }
    }
}