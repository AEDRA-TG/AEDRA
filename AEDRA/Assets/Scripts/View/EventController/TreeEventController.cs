using System.Collections.Generic;
using UnityEngine;
using SideCar.DTOs;
using Controller;
using Utils.Enums;
using UnityEngine.UI;
using System;

namespace View.EventController
{
    /// <summary>
    /// Events controller that recives all the OnClick methods of the tree options
    /// </summary>

    public class TreeEventController : AppEventController
    {

        public void Start(){
            base._menus = new Dictionary<MenuEnum, GameObject>{
                {MenuEnum.MainMenu, gameObject.transform.Find("MainMenu").gameObject},
                {MenuEnum.TraversalMenu, gameObject.transform.Find("TraversalMenu").gameObject},
                {MenuEnum.AddElementInputMenu, gameObject.transform.Find("AddElementInputMenu").gameObject},
                {MenuEnum.RemoveElementInputMenu, gameObject.transform.Find("RemoveElementInputMenu").gameObject},
                {MenuEnum.SearchElementInputMenu, gameObject.transform.Find("SearchElementInputMenu").gameObject},
                { MenuEnum.AnimationControlMenu, gameObject.transform.Find("AnimationControlMenu").gameObject}
            };
            base._activeSubMenu = MenuEnum.MainMenu;
            base.ChangeToMenu(MenuEnum.MainMenu);
        }

        /// <summary>
        /// Graph controller subscribes to update menu event for updating UI
        /// </summary>
        public void OnEnable() {
            SelectionController.OnEmptyTouch += OnEmptyTouch;
        }

        /// <summary>
        /// Projection unsubscribes to update menu event for updating UI
        /// </summary>
        public void OnDisable() {
            SelectionController.OnEmptyTouch -= OnEmptyTouch;
        }

        /// <summary>
        /// Hide menus when touching empty space
        /// </summary>
        public void OnEmptyTouch(){
            GameObject BackOptionsMenu = GameObject.Find("BackOptionsMenu");
            if(_activeSubMenu.ToString().Contains("Input")){
                ChangeToMenu(MenuEnum.MainMenu);
            }
            BackOptionsMenu?.SetActive(false);
        }

        /// <summary>
        /// Method to detect when the user taps on add node button
        /// </summary>
        public void OnTouchAddNode(){
            //!!TODO: this should accept other types of values
            int value = Int32.Parse(FindObjectOfType<InputField>().text);
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, value, null, true, null, null);
            AddElementCommand addCommand = new AddElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(addCommand);
            base.ChangeToMenu(MenuEnum.MainMenu);
        }

        /// <summary>
        /// Method to detect when the user taps on delete node button
        /// </summary>
        public void OnTouchDeleteNode(){
            //!!TODO: this should accept other types of values
            int value = Int32.Parse(FindObjectOfType<InputField>().text);
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, value, null, true, null, null);
            DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(deleteCommand);
            base.ChangeToMenu(MenuEnum.MainMenu);
        }

        /// <summary>
        /// Method to detect when the user taps on pre order traversal button
        /// </summary>
        public void OnTouchPreOrderTraversal(){
            base.IsAnimationControlEnable = true;
            DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.TreePreOrder,null);
            CommandController.GetInstance().Invoke(traversalCommand);
        }

        /// <summary>
        /// Method to detect when the user taps on in order traversal button
        /// </summary>
        public void OnTouchInOrderTraversal(){
            base.IsAnimationControlEnable = true;
            DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.TreeInOrder,null);
            CommandController.GetInstance().Invoke(traversalCommand);
        }

        /// <summary>
        /// Method to detect when the user taps on post traversal button
        /// </summary>
        public void OnTouchPostOrderTraversal(){
            base.IsAnimationControlEnable = true;
            DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.TreePostOrder,null);
            CommandController.GetInstance().Invoke(traversalCommand);
        }

        /// <summary>
        /// Method to detect when the user taps on search value
        /// </summary>
        public void OnTouchSearchValue(){
            //!!TODO: this should accept other types of values
            int value = Int32.Parse(FindObjectOfType<InputField>().text);
            base.ChangeToMenu(MenuEnum.AnimationControlMenu);
            ElementDTO elementToSearch = new BinarySearchNodeDTO(0, value, null, true, null, null);
            DoAlgorithmCommand algorithmCommand = new DoAlgorithmCommand(AlgorithmEnum.BinarySearch,new List<ElementDTO>(){elementToSearch});
            CommandController.GetInstance().Invoke(algorithmCommand);
        }
    }
}