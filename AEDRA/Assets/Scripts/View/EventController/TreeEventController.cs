using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using Utils;
using SideCar.DTOs;
using Controller;
using Utils.Enums;

namespace View.EventController
{
    /// <summary>
    /// Events controller that recives all the OnClick methods of the tree options
    /// </summary>

    public class TreeEventController : AppEventController
    {
        [SerializeField] public int value;

        public void Awake(){
            base._menus = new Dictionary<MenuEnum, GameObject>(){
                {MenuEnum.MainMenu, gameObject.transform.Find("MainMenu").gameObject},
                {MenuEnum.TraversalMenu, gameObject.transform.Find("TraversalMenu").gameObject},
                {MenuEnum.AddElementInputMenu, gameObject.transform.Find("AddElementInputMenu").gameObject},
                {MenuEnum.RemoveElementInputMenu, gameObject.transform.Find("RemoveElementInputMenu").gameObject},
                {MenuEnum.SearchElementInputMenu, gameObject.transform.Find("SearchElementInputMenu").gameObject}
            };
            base._activeMenu = MenuEnum.MainMenu;
        }

        public void OnTouchAddNode(){
            //!!TODO: this could be another kind of tree node
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, this.value, null, true, null, null);
            AddElementCommand addCommand = new AddElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(addCommand);
        }

        public void OnTouchDeleteNode(){
            //!!TODO: this could be another kind of tree node
            BinarySearchNodeDTO nodeDTO = new BinarySearchNodeDTO(0, this.value, null, true, null, null);
            DeleteElementCommand deleteCommand = new DeleteElementCommand(nodeDTO);
            CommandController.GetInstance().Invoke(deleteCommand);
        }

        //TODO this code is part of refactor (do not modify this logic plis, contact IT support if you have issues)
        public void ChangeToTraversalMenu(){
            OptionsMenu menu = FindObjectOfType<OptionsMenu>();
            menu.ChangeMenu(1);
        }
    }
}