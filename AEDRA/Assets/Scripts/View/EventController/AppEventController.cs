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
        protected MenuEnum _activeSubMenu;
        private GameObject _activeMenu;

        /// <summary>
        /// Method that executes when a target is detected by the camera
        /// </summary>
        public void OnTargetDetected(TargetParameter targetParameter){
            StructureProjection projection = GameObject.FindObjectOfType<StructureProjection>();
            projection.Name = targetParameter.GetStructure().ToString();
            Command command = new LoadCommand(projection.Name);
            CommandController.GetInstance().Invoke(command);
            if(_activeMenu != null){
                Destroy(_activeMenu);
            }
            _activeMenu = Instantiate(targetParameter.GetPrefabMenu(), new Vector3(0,0,0), Quaternion.identity, GameObject.Find(Constants.MenusParentName).transform);
            _activeMenu.transform.localPosition = new Vector3(0,0,0);
        }

        /// <summary>
        /// Method that executes when a target is lost by the camera
        /// </summary>
        public void OnTargetLost(){
            Command command = new SaveCommand();
            CommandController.GetInstance().Invoke(command);
        }

        public void ChangeToMenu(MenuEnumParameter menu){
            GameObject activeMenu = _menus[_activeSubMenu];
            activeMenu?.SetActive(false);
            GameObject newMenu = _menus[menu.GetMenu()];
            newMenu?.SetActive(true);
            _activeSubMenu = menu.GetMenu();
        }

        protected void ChangeToMenu(MenuEnum menu){
            MenuEnumParameter menuEnumParameter = new MenuEnumParameter();
            menuEnumParameter.SetMenu(menu);
            ChangeToMenu(menuEnumParameter);
        }

        public void ChangeScene(int nextPage)
        {
            SceneManager.LoadScene(nextPage);
        }
    }
}