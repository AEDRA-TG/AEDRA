using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Utils.Enums;
using Utils.Parameters;
using View.GUI;

namespace View.EventController
{
    public class AppEventController: MonoBehaviour
    {
        protected Dictionary<MenuEnum, GameObject> _menus;
        protected MenuEnum _activeMenu;
        public void Start(){
            //TODO: Comment this line
            OnTargetDetected();
        }

        /// <summary>
        /// Method that executes when a target is detected by the camera
        /// </summary>
        public void OnTargetDetected(){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.Name = "BinarySearchTree";
            Command command = new LoadCommand(projection.Name);
            CommandController.GetInstance().Invoke(command);
        }

        /// <summary>
        /// Method that executes when a target is lost by the camera
        /// </summary>
        public void OnTargetLost(){
            Command command = new SaveCommand();
            CommandController.GetInstance().Invoke(command);
        }

        public void ChangeToMenu(MenuEnumParameter menu){
            GameObject activeMenu = _menus[_activeMenu];
            activeMenu?.SetActive(false);
            GameObject newMenu = _menus[menu.GetMenu()];
            newMenu?.SetActive(true);
            _activeMenu = menu.GetMenu();
        }

        public void ChangeScene(int nextPage)
        {
            SceneManager.LoadScene(nextPage);
        }
    }
}