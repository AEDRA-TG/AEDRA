using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using Utils;
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
        public void Awake(){
            base._menus = new Dictionary<MenuEnum, GameObject>(){
                {MenuEnum.MainMenu, gameObject.transform.Find("MainMenu").gameObject},
                {MenuEnum.TraversalMenu, gameObject.transform.Find("TraversalMenu").gameObject},
                {MenuEnum.AddElementInputMenu, gameObject.transform.Find("AddElementInputMenu").gameObject},
                {MenuEnum.RemoveElementInputMenu, gameObject.transform.Find("RemoveElementInputMenu").gameObject},
                {MenuEnum.SearchElementInputMenu, gameObject.transform.Find("SearchElementInputMenu").gameObject}
            };
            base._activeSubMenu = MenuEnum.MainMenu;
        }

        public void OnTouchAddNode(){
            //!!TODO: this should accept other types of values
            int value = Int32.Parse(FindObjectOfType<InputField>().text);
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, value, null, true, null, null);
            AddElementCommand addCommand = new AddElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(addCommand);
        }

        public void OnTouchDeleteNode(){
            //!!TODO: this should accept other types of values
            int value = Int32.Parse(FindObjectOfType<InputField>().text);
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, value, null, true, null, null);
            DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(deleteCommand);
        }

        public void OnTouchPreOrderTraversal(){
            DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.TreePreOrder,null);
            CommandController.GetInstance().Invoke(traversalCommand);
        }
        public void OnTouchInOrderTraversal(){
            DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.TreeInOrder,null);
            CommandController.GetInstance().Invoke(traversalCommand);
        }
        public void OnTouchPostOrderTraversal(){
            DoTraversalCommand traversalCommand = new DoTraversalCommand(TraversalEnum.TreePostOrder,null);
            CommandController.GetInstance().Invoke(traversalCommand);
        }
    }
}