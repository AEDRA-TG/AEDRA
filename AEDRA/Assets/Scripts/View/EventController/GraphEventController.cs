using UnityEngine;
using Controller;
using Model.GraphModel;
using SideCar.DTOs;

namespace View.EventController
{
    /// <summary>
    /// Class to manage events received from an action executed on a graph by the user
    /// </summary>
    public class GraphEventController : MonoBehaviour
    {

        // TODO : BORRAR
        [SerializeField] private int id1;
        [SerializeField] private int id2;

        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode(int data){
            AddElementCommand addCommand = new AddElementCommand(data);
            CommandController.GetInstance().Invoke(addCommand);
        }

        /// <summary>
        /// Method to detect when the user taps on delete node button
        /// </summary>
        public void OnTouchDeleteNode(int id){
            // TODO: Get selected object
            // Convert selected object to DTO
            GraphNodeDTO nodeDTO = new GraphNodeDTO(id, 0, null);
            DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(deleteCommand);
        }

        public void OnTouchConnectNodes(){
            GraphEdgeDTO edgeDTO = new GraphEdgeDTO(id1, 0, id2);
            ConnectElementsCommand connectCommand = new ConnectElementsCommand(edgeDTO);
            CommandController.GetInstance().Invoke(connectCommand);
        }


    }
}