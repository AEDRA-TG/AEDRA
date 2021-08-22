using UnityEngine;
using Controller;
using Model.GraphModel;
using SideCar.DTOs;
using Utils.Enums;

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
            GraphNodeDTO nodeDTO = new GraphNodeDTO(id, 0, null);
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
            GraphNodeDTO nodeDTO = new GraphNodeDTO(id, 0, null);
            DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(deleteCommand);
        }

        public void OnTouchConnectNodes()
        {
            //TODO: fix element selection to obtain edge
            int idEdge = new System.Random().Next(100);
            GraphEdgeDTO edgeDTO = new GraphEdgeDTO(idEdge, id, 0, id2);
            ConnectElementsCommand connectCommand = new ConnectElementsCommand(edgeDTO);
            CommandController.GetInstance().Invoke(connectCommand);
        }
    }
}