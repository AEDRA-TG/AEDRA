using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using Utils;
using SideCar.DTOs;
using Controller;

namespace View.EventController
{
    /// <summary>
    /// Events controller that recives all the OnClick methods of the tree options
    /// </summary>

    public class TreeEventController : MonoBehaviour
    {
        [SerializeField] public int value;
        /// <summary>
        /// Method that recive the click of the traversal button on options menu delegate prefabs change to OptionsMenu class
        /// </summary>
        /// <param name="prefabPath">The text that indicates the prefabs path</param>
        /// <param name="instanceName">The name that instance prefab will have</param>
        /// <param name="parent">The parent of the prefab name</param>

        public void OnTouchAddNode(){
            //!!TODO: this could be another kind of tree node
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, this.value, null, true, null, null);
            AddElementCommand addCommand = new AddElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(addCommand);
        }

        //TODO this code is part of refactor (do not modify this logic plis, contact IT support if you have issues)
        public void ChangeToTraversalMenu(){
            OptionsMenu menu = FindObjectOfType<OptionsMenu>();
            menu.ChangeMenu(1);
        }
    }
}